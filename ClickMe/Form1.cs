using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WindowsInput;
using WindowsInput.Native;
using static ClickMe.KeyCodes;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace ClickMe
{

    public partial class Form1 : Form
    {


        private int currIndex;
        public int intervals = 500;
        public bool click = false;
        public int parsedValue = 1;
        public PositionHelper positionHelper = new PositionHelper();
        private InputSimulator inputSimulator;
        private KeyboardListener KListener = new KeyboardListener();
        private MouseHook mouseHook = new MouseHook();
        private Stopwatch timer = new Stopwatch();
        private const String f6 = "F6";
        private Key? currentKeyPressed = null;

        public Form1()
        {
            inputSimulator = new InputSimulator();
            KListener.KeyDown += new RawKeyEventHandler(keyDownEvent);
            KListener.KeyUp += new RawKeyEventHandler(keyUpEvent);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currIndex = 0;
            CheckForIllegalCrossThreadCalls = false;
            Thread AC = new Thread(AutoClick);
            backgroundWorker1.RunWorkerAsync();
            AC.Start();
        }

        private void AutoClick()
        {
            while (true)
            {
                if (checkBox1.Checked && click && PositionHelper.positions.Count > 0)
                {
                    executeClick(PositionHelper.positions[currIndex]);
                }
            }
        }
        void keyDownEvent(object sender, RawKeyEventArgs args)
        {
            Console.WriteLine("key / mouse: " + args.Key.ToString());
            currentKeyPressed = args.Key;
            if (String.Equals(args.Key.ToString(), f6))
            {
                click = !click;
                Console.WriteLine("Stopped");
            }
        }
        void keyUpEvent(object sender, RawKeyEventArgs args)
        {
            Console.WriteLine("Key up: " + args.Key.ToString());
            currentKeyPressed = null;
        }

        private void executeClick(MousePosition mousePosition)
        {
            int xp = mousePosition.x;
            int yp = mousePosition.y;

            Console.WriteLine($"Move to: ({xp}, {yp}), with delay: {mousePosition.delay}");
            MouseHelper.POINT p = new MouseHelper.POINT(xp, yp);
            MouseHelper.ClientToScreen(Handle, ref p);
            MouseHelper.SetCursorPos(getRandInt(xp), getRandInt(yp));

            //inputSimulator.Mouse.MoveMouseTo(getRandInt(xp), getRandInt(yp));

            if (mousePosition.useModifier && mousePosition.modifier.HasValue)
            {
                MouseHelper.SendKeyCommand((KeyCode)virtualKeyToKeyCode(mousePosition.modifier.Value), MouseHelper.KEYEVENT_KEYDOWN);
                Thread.Sleep(1);
            }

            if (mousePosition.isDoubleClick)
            {
                if (mousePosition.isRightClick)
                {
                    inputSimulator.Mouse.RightButtonDoubleClick();
                }
                else
                {
                    inputSimulator.Mouse.LeftButtonDoubleClick();
                }
            }
            else
            {
                if (mousePosition.isRightClick)
                {
                    inputSimulator.Mouse.RightButtonClick();
                }
                else
                {
                    inputSimulator.Mouse.LeftButtonClick();
                }
            }

            if (mousePosition.useModifier)
            {
                MouseHelper.SendKeyCommand((KeyCode)virtualKeyToKeyCode(mousePosition.modifier), MouseHelper.KEYEVENT_KEYUP);
            }

            ++currIndex;
            if (currIndex >= PositionHelper.positions.Count)
            {
                currIndex = 0;
            }

            Thread.Sleep(mousePosition.delay);
            
        }

        private int getRandInt(int pt)
        {
            if (randomizePositions.Checked)
            {
                int seed = 2;
                if (positionModifier.Value > 0)
                {
                    seed = Decimal.ToInt32(positionModifier.Value);
                }
                Random rnd = new Random();
                int rand = rnd.Next(-seed, seed);
                pt += rand;
            }
            return pt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(globalDelay.Text, out int parsedValue))
            {
                MessageBox.Show("Please enter a number");
            }
            else
            {
                intervals = parsedValue;
            }
        }

        private void addRowBtn_Click(object sender, EventArgs e)
        {
            int.TryParse(globalDelay.Text, out int delay);
            var formPopup = new PositionPopup(delay);
            formPopup.FormClosing += new FormClosingEventHandler(onPopupClose);
            formPopup.Show(this);
        }

        public void onPopupClose(object sender, FormClosingEventArgs e)
        {
            positionList.Items.Clear();
            clearPositions();
        }

        private void clearPositions()
        {
            if (PositionHelper.positions.Count > 0)
            {
                PositionHelper.positions.ForEach(x =>
                {
                    appendClickPositionLabel(x);
                });
            }
        }

        private void appendClickPositionLabel(MousePosition x, String mod = "")
        {
            var lbl = "";
            if (string.IsNullOrEmpty(x.label))
            {
                lbl = positionList.Items.Count + 1 + "";
            }
            else
            {
                lbl = x.label;
            }

            if (!string.IsNullOrEmpty(mod))
            {
                lbl += " + " + mod;
            }

            String txt = $" - {lbl}, X: {x.x}, Y: {x.y}, Delay: {x.delay} (ms)";
            positionList.Items.Add(txt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var item = positionList.SelectedItem;
            if (item != null)
            {
                var txt = item as String;
                var lbl = txt.Split('-')[1].Split(',')[0].Trim();
                PositionHelper.removeItem(lbl);
                positionList.Items.Remove(item);
            }
        }

        private bool isRecording = false;
        private string recordBtnOffTxt = "Record Mouse";
        private string recordBtnOnTxt = "Stop Recording";
        private int lastElapsedTime = 0;

        private void beginMouseRecording_Click(object sender, EventArgs e)
        {
            isRecording = !isRecording;

            if (isRecording)
            {
                beginMouseRecording.Text = recordBtnOnTxt;
                timer.Start();
                recordMouse();
            }
            else
            {
                beginMouseRecording.Text = recordBtnOffTxt;
                mouseHook.UnHook();
                timer.Stop();
                Thread.Sleep(20);
                PositionHelper.positions.Remove(PositionHelper.positions.Last());
            }
        }

        /*
         * TODO: BG thread to capture mouse input
         * 
         * Add global timer to auto detect delays between clicks
         * 
         */
        private void recordMouse()
        {
            mouseHook.SetHook();
            mouseHook.MouseMoveEvent += mh_MouseMoveEvent;
            mouseHook.MouseClickEvent += mh_MouseClickEvent;
            mouseHook.MouseDownEvent += mh_MouseDownEvent;
            mouseHook.MouseUpEvent += mh_MouseUpEvent;
        }

        private void mh_MouseDownEvent(object sender, MouseEventArgs e)
        {
            string sText = "";
            int dly = (int)timer.ElapsedMilliseconds - lastElapsedTime;
            lastElapsedTime = (int)timer.ElapsedMilliseconds;
            int x = e.Location.X;
            int y = e.Location.Y;
            bool isRightClk = true;
            VirtualKeyCode kCode = VirtualKeyCode.RBUTTON;
            Key? modifierKey = null;
            string modStr = "";
            bool isModified = false;

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (e.Button == MouseButtons.Left)
                {
                    sText = "(" + e.X.ToString() + "," + e.Y.ToString() + ")";
                    isRightClk = false;
                    kCode = VirtualKeyCode.LBUTTON;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    sText = "(" + e.X.ToString() + "," + e.Y.ToString() + ")";
                    isRightClk = true;
                    kCode = VirtualKeyCode.RBUTTON;
                }

                if (currentKeyPressed.HasValue)
                {
                    modifierKey = currentKeyPressed.Value;
                    modStr = modifierKey.ToString();
                    isModified = true;
                }

                var mp = new MousePosition(sText, x, y, dly, isRightClk, false, kCode, modifierKey, isModified);
                PositionHelper.addItem(mp);
                appendClickPositionLabel(mp, modStr);
            }
        }

        private static KeyCode? virtualKeyToKeyCode(VirtualKeyCode? key) => key switch
        {
            VirtualKeyCode.SHIFT => KeyCode.SHIFT,
            VirtualKeyCode.MENU => KeyCode.ALT,
            VirtualKeyCode.CONTROL => KeyCode.CONTROL,
            _ => null,
        };

        private void mh_MouseUpEvent(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                //richTextBox1.AppendText("Left Button Release\n");
            }
            if (e.Button == MouseButtons.Right)
            {
                //richTextBox1.AppendText("Right Button Release\n");
            }

        }
        private void mh_MouseClickEvent(object sender, MouseEventArgs e)
        {
            
        }

        private void mh_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            xPosition.Text = x + "";
            yPosition.Text = y + "";
        }

        private void label2_Click(object sender, EventArgs e) { }

        private void positionList_SelectedIndexChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void positionList_SelectedIndexChanged_1(object sender, EventArgs e) { }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) { }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to clear the list?", "Warning", MessageBoxButtons.YesNoCancel);
            
            if (res == DialogResult.Yes)
            {
                PositionHelper.positions.Clear();
                positionList.Items.Clear();
            }
        }
    }
}
