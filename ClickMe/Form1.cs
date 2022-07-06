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
        private int clickCount = 0;
        private Key? customStartStop = null;
        private bool isModalOpen = false;

        private string forNumberOfLoops = "For number of loops";
        private string untilSpecifiedTime = "Until specified time";
        private string startBtnTxt = "Start (F6)";
        private string stopBtnTxt = "Stop (F6)";

        private bool isRecording = false;
        private string recordBtnOffTxt = "Record Mouse";
        private string recordBtnOnTxt = "Stop Recording";
        private int lastElapsedTime = 0;

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
            startStopSelect.DataSource = Enum.GetValues(typeof(Key));
            startStopSelect.SelectedItem = Key.F6;
            CheckForIllegalCrossThreadCalls = false;
            Thread AC = new Thread(AutoClick);
            backgroundWorker1.RunWorkerAsync();
            AC.Start();
        }

        private void startStopBtn_Click(object sender, EventArgs e)
        {
            if (!click && PositionHelper.positions.Count < 1)
            {
                var res = MessageBox.Show("You havn't added any clicks yet.", "Warning");
            }
            else
            {
                click = !click;
            }
            updateBtnColorAndText();
        }

        /*
         *  Until Stopped (F6)
         *  For number of loops
         *  Until specified time
         */
        private void AutoClick()
        {
            while (true)
            {
                if (enableStartStopBtn.Checked && click && PositionHelper.positions.Count > 0)
                {
                    if (string.Equals(repeatFor.Text, forNumberOfLoops) && checkValidClickCount())
                    {
                        executeClick(PositionHelper.positions[currIndex]);
                        clickCount++;
                    }
                    else if (string.Equals(repeatFor.Text, untilSpecifiedTime) && checkValidRunTime())
                    {
                        executeClick(PositionHelper.positions[currIndex]);
                        clickCount++;
                    }
                    else
                    {
                        executeClick(PositionHelper.positions[currIndex]);
                    }
                }
            }
        }

        private bool checkValidRunTime()
        {
            int hours = Decimal.ToInt32(hrSelect.Value) * 60 * 60 * 1000;
            int minutes = Decimal.ToInt32(mnSelect.Value) * 60 * 1000;
            int seconds = Decimal.ToInt32(scSelect.Value) * 1000;

            return timer.ElapsedMilliseconds < (hours + minutes + seconds);
        }

        private bool checkValidClickCount()
        {
            int maxClicks = Decimal.ToInt32(repeatCount.Value);
            return clickCount < maxClicks;
        }

        private void updateBtnColorAndText()
        {
            if (click)
            {
                startStopBtn.BackColor = Color.Red;
            }
            else
            {
                startStopBtn.BackColor = Color.Green;
            }
            startStopBtn.Text = string.Equals(startStopBtn.Text, startBtnTxt) ? stopBtnTxt : startBtnTxt;
        }

        /// <summary>
        /// Watch for key presses.
        /// If F6 pressed, stop the click loop and reset clickCount.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void keyDownEvent(object sender, RawKeyEventArgs args)
        {
            currentKeyPressed = args.Key;
            var kcd = customStartStop.HasValue && customStartStop != Key.None ? 
                customStartStop.Value.ToString() : f6;
            Console.WriteLine("key / mouse: " + args.Key.ToString());
            if (String.Equals(args.Key.ToString(), kcd))
            {
                if (!click && isModalOpen)
                {
                    MessageBox.Show("Please close the popup before running.", "Warning");
                }
                else
                {
                    click = !click;
                }
                updateBtnColorAndText();
                clickCount = 0;
            }
        }

        // Reset clicked button when it is released
        void keyUpEvent(object sender, RawKeyEventArgs args)
        {
            Console.WriteLine("Key up: " + args.Key.ToString());
            currentKeyPressed = null;
        }

        /// <summary>
        /// General click event.
        /// </summary>
        /// <param name="mousePosition"></param>
        private void executeClick(MousePosition mousePosition)
        {
            int xp = mousePosition.x;
            int yp = mousePosition.y;

            Console.WriteLine($"Move to: ({xp}, {yp}), with delay: {mousePosition.delay}");
            MouseHelper.POINT p = new MouseHelper.POINT(xp, yp);
            MouseHelper.ClientToScreen(Handle, ref p);

            (var xx, var yy) = getRandIntTuple(xp, yp);
            MouseHelper.SetCursorPos(xx, yy);

            var code = virtualKeyToKeyCode(mousePosition.modifier);

            if (mousePosition.useModifier && code != null)
            {
                MouseHelper.SendKeyCommand((KeyCode)code, MouseHelper.KEYEVENT_KEYDOWN);
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

        /// <summary>
        /// Randomize the click positions by 'positionModifier' amount of pixels
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private (int,int) getRandIntTuple(int x, int y)
        {
            if (randomizePositions.Checked)
            {
                int seed = 2;
                if (positionModifier.Value > 0)
                {
                    seed = Decimal.ToInt32(positionModifier.Value);
                }
                Random rndX = new Random();
                Random rndY = new Random();
                int rx = rndX.Next(0, seed);
                int ry = rndX.Next(0, seed);
                bool xPos = rndX.Next(1, 10) > 5;
                bool yPos = rndY.Next(1, 10) > 5;
                rx = xPos ? rx : -rx;
                ry = yPos ? ry : -ry;

                Console.WriteLine($"Random Val, x: {rx}, y: {ry} ");

                return (x + rx, y + ry);
            }
            return (x, y);
        }

        // Set a global delay
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

        // Trigger to open the add click position row popup
        private void addRowBtn_Click(object sender, EventArgs e)
        {
            int.TryParse(globalDelay.Text, out int delay);
            var formPopup = new PositionPopup(delay);
            isModalOpen = true;
            formPopup.FormClosing += new FormClosingEventHandler(onPopupClose);
            formPopup.Show(this);
        }

        /// <summary>
        /// Run this when the popup closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void onPopupClose(object sender, FormClosingEventArgs e)
        {
            isModalOpen = false;
            updatePositions();
        }

        /// <summary>
        /// Refresh the click position list
        /// </summary>
        private void updatePositions()
        {
            if (PositionHelper.positions.Count > 0)
            {
                positionList.Items.Clear();
                PositionHelper.positions.ForEach(x =>
                {
                    appendClickPositionLabel(x);
                });
            }
            else
            {
                positionList.Items.Clear();
            }
        }

        /// <summary>
        /// Append a new click position to the list
        /// </summary>
        /// <param name="x"></param>
        /// <param name="mod"></param>
        private void appendClickPositionLabel(MousePosition x, String mod = "")
        {
            var lbl = "";
            var md = "";
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
                md += " + " + mod;
            }

            String txt = $" - {lbl}, X: {x.x}, Y: {x.y}, Delay: {x.delay} (ms) {md}";
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

        private void beginMouseRecording_Click(object sender, EventArgs e)
        {
            isRecording = !isRecording;

            if (isRecording)
            {
                beginMouseRecording.Text = recordBtnOnTxt;
                recordMouse();
            }
            else
            {
                beginMouseRecording.Text = recordBtnOffTxt;
                mouseHook.UnHook();
                timer.Stop();
                Thread.Sleep(20);
                PositionHelper.positions.Remove(PositionHelper.positions.Last());
                updatePositions();
            }
        }

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
            bool isFirstClick = false;
            if (!timer.IsRunning)
            {
                timer.Start();
                isFirstClick = true;
            }
            string sText = "";
            int dly = (int)timer.ElapsedMilliseconds - lastElapsedTime;
            lastElapsedTime = (int)timer.ElapsedMilliseconds;

            if (!isFirstClick && dly <= 2)
            {
                return; 
            }

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

                var mp = new MousePosition(sText, x, y, dly, isRightClk, false, 
                    KeyToVirtualKeyCode(modifierKey), modifierKey, isModified);
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

        private static VirtualKeyCode? KeyToVirtualKeyCode(Key? key) => key switch
        {
            Key.LeftShift => VirtualKeyCode.SHIFT,
            Key.LeftAlt => VirtualKeyCode.MENU,
            Key.LeftCtrl  => VirtualKeyCode.CONTROL,
            _ => null,
        };

        private void mh_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            xPosition.Text = x + "";
            yPosition.Text = y + "";
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

        private void repeatFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.Equals(repeatFor.Text, forNumberOfLoops, StringComparison.OrdinalIgnoreCase))
            {
                repeatSelection.Text = "Total Clicks: ";
                repeatSelection.Visible = true;
                repeatCount.Visible = true;
            }
            else if (string.Equals(repeatFor.Text, untilSpecifiedTime, StringComparison.OrdinalIgnoreCase))
            {
                repeatSelection.Text = "Total Time: ";
                repeatCount.Visible = false;
                repeatSelection.Visible = true;
                hrLbl.Visible = true;
                mnLbl.Visible = true;
                scLbl.Visible = true;
                hrSelect.Visible = true;
                mnSelect.Visible = true;
                scSelect.Visible = true;
            }
            else
            {
                repeatCount.Visible = false;
                repeatSelection.Visible = false;
                hrLbl.Visible = false;
                mnLbl.Visible = false;
                scLbl.Visible = false;
                hrSelect.Visible = false;
                mnSelect.Visible = false;
                scSelect.Visible = false;
            }
        }

        private void startStopSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            customStartStop = (Key)startStopSelect.SelectedItem;
            Console.WriteLine("key / mouse: " + customStartStop.ToString());
            updateStartStopLabels(customStartStop.ToString());
        }

        private void updateStartStopLabels(String keyLbl)
        {
            enableStartStopBtn.Text = $"Enable {keyLbl} Start / Stop";
            topLabel.Text = $"{keyLbl} to start and stop";
            startBtnTxt = $"Start ({keyLbl})";
            stopBtnTxt = $"Stop ({keyLbl})";
            updateBtnColorAndText();
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void positionList_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void positionList_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void mh_MouseClickEvent(object sender, MouseEventArgs e) { }
        private void mh_MouseUpEvent(object sender, MouseEventArgs e) { }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e) { }
    }
}
