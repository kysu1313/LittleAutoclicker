using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
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
        private Stopwatch clickTimer = new Stopwatch();
        private const String f6 = "F6";
        private Key? currentKeyPressed = null;
        private int clickCount = 0;
        private int loopCount = 0;
        private Key? customStartStop = null;
        private Key? customRecord = null;
        private bool isModalOpen = false;
        private Key? globalModifier;
        private short currentGlobalModifierKey;
        private bool globalModifierEnabled = false;
        private bool globalModifierIsDown = false;
        private bool recordBtnEnabled = true;
        private bool globalDelayEnabled = false;
        private int globalDelayValue = 0;

        private string forNumberOfLoops = "For number of loops";
        private string untilSpecifiedTime = "Until specified time";
        private string forNumberOfClicks = "For number of clicks";
        private string startBtnTxt = "Start (F6)";
        private string stopBtnTxt = "Stop (F6)";

        private bool isRecording = false;
        private string recordBtnOffTxt = "Record Mouse (F7)";
        private string recordBtnOnTxt = "Stop Recording (F7)";
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
            customStartStop = Key.F7;
            loadToolStripMenuItem.Click += new EventHandler(loadFile);
            globalModifierKey.DataSource = Enum.GetValues(typeof(Key));
            startStopSelect.DataSource = Enum.GetValues(typeof(Key));
            startStopSelect.SelectedItem = Key.F6;
            customRecordBtn.DataSource = Enum.GetValues(typeof(Key));
            customRecordBtn.SelectedItem = Key.F7;
            positionList.DoubleClick += PositionList_DoubleClick;
            positionList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            CheckForIllegalCrossThreadCalls = false;
            beginMouseRecording.Text = recordBtnOffTxt;
            Thread AC = new Thread(AutoClick);
            backgroundWorker1.RunWorkerAsync();
            AC.Start();
        }

        private void PositionList_DoubleClick(object sender, EventArgs e)
        {
            var row = positionList.SelectedItems[0].Tag;
            if (row != null)
            {
                var lvi = (MousePosition)row;
                var formPopup = new PositionPopup(lvi);
                isModalOpen = true;
                formPopup.FormClosing += new FormClosingEventHandler(onPopupClose);
                formPopup.Show(this);
            }
        }

        private void startStopBtn_Click(object sender, EventArgs e)
        {
            startStopLoopAction();
        }

        private void startStopLoopAction()
        {
            if (!click && PositionHelper.positions.Count < 1)
            {
                var res = MessageBox.Show("You havn't added any clicks yet.", "Warning");
                return;
            }
            else if (!click && isModalOpen)
            {
                MessageBox.Show("Please close the popup before running.", "Warning");
                return;
            }
            else if (!click && isRecording)
            {
                MessageBox.Show("You need to stop recording first.", "Warning");
                return;
            }
            else
            {
                if (globalModifierEnabled && !isModalOpen)
                {
                    triggerGlobalModifier(false);
                }
                if (click)
                {
                    loopCount = 0;
                    clickCount = 0;
                }
                click = !click;
                if (clickTimer.IsRunning)
                {
                    clickTimer.Stop();
                    clickTimer.Reset();
                }
                else
                    clickTimer.Start();
            }
            updateBtnColorAndText();
            clickCount = 0;
        }

        /*
         *  Repeat:
         *      Until Stopped (F6)
         *      For number of loops
         *      Until specified time
         */
        private void AutoClick()
        {
            while (true)
            {
                if (enableStartStopBtn.Checked && click && PositionHelper.positions.Count > 0)
                {
                    if (globalModifierEnabled && !globalModifierIsDown)
                    {
                        triggerGlobalModifier(true);
                    }
                    if (string.Equals(repeatFor.Text, forNumberOfLoops) && checkValidLoopCount())
                    {
                        executeClick(PositionHelper.positions[currIndex]);
                        clickCount++;
                    }
                    else if (string.Equals(repeatFor.Text, forNumberOfClicks) && checkValidClickCount())
                    {
                        executeClick(PositionHelper.positions[currIndex]);
                        clickCount++;
                    }
                    else if (string.Equals(repeatFor.Text, untilSpecifiedTime) && checkValidRunTime())
                    {
                        executeClick(PositionHelper.positions[currIndex]);
                        clickCount++;
                    }
                    else if (!string.Equals(repeatFor.Text, forNumberOfLoops) &&
                        !string.Equals(repeatFor.Text, untilSpecifiedTime))
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

            if (clickTimer.ElapsedMilliseconds > (hours + minutes + seconds))
            {
                click = !click;
                updateBtnColorAndText();
                return false;
            }
            return true;
        }

        private bool checkValidClickCount()
        {
            int maxClicks = Decimal.ToInt32(repeatCount.Value);
            if (clickCount > maxClicks)
            {
                click = !click;
                updateBtnColorAndText();
                return false;
            }
            return true;
        }

        private bool checkValidLoopCount()
        {
            int maxLoops = Decimal.ToInt32(repeatLoopCount.Value);
            if (loopCount > maxLoops)
            {
                click = !click;
                updateBtnColorAndText();
                return false;
            }
            return true;
        }

        private void triggerGlobalModifier(bool isPressDown)
        {
            if (isPressDown)
            {
                currentGlobalModifierKey = (short)(Keys)KeyToKeys(globalModifier);
                MouseHelperAdv.SendKey(currentGlobalModifierKey, 0, false, true, false);
                //MouseHelper.SendKeyCommand((KeyCode)KeyToKeyCode(globalModifier), MouseHelper.KEYEVENT_KEYDOWN);
                globalModifierIsDown = true;
            }
            else
            {
                MouseHelperAdv.SendKey(currentGlobalModifierKey, 0, false, false, true);
                //MouseHelper.SendKeyCommand((KeyCode)KeyToKeyCode(globalModifier), MouseHelper.KEYEVENT_KEYUP);
                globalModifierIsDown = false;
            }
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
            //Console.WriteLine("key / mouse: " + args.Key.ToString());
            if (String.Equals(args.Key.ToString(), kcd))
            {
                startStopLoopAction();
            }
            if (String.Equals(args.Key.ToString(), customRecord.ToString()))
            {
                recordButtonClickAction(true);
            }
        }

        // Reset clicked button when it is released
        void keyUpEvent(object sender, RawKeyEventArgs args)
        {
            //Console.WriteLine("Key up: " + args.Key.ToString());
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
                Console.WriteLine("pressed " + code);
                //inputSimulator.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
                //Thread.Sleep(1);
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

            if (mousePosition.useModifier && code != null)
            {
                MouseHelper.SendKeyCommand((KeyCode)code, MouseHelper.KEYEVENT_KEYUP);
                //MouseHelper.SendKeyCommand((KeyCode)virtualKeyToKeyCode(mousePosition.modifier), MouseHelper.KEYEVENT_KEYUP);
                //inputSimulator.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
            }

            ++currIndex;
            if (currIndex >= PositionHelper.positions.Count)
            {
                currIndex = 0;
                loopCount++;
            }

            if (globalDelayEnabled)
            {
                Thread.Sleep(globalDelayValue);
            }
            else
            {
                Thread.Sleep(mousePosition.delay);
            }
            
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
            else if (x.modifier != null)
            {
                md += " + " + x.modifier.ToString();
            }

            var clickType = x.isDoubleClick ? "D" : x.isRightClick ? "R" : "L";
            string[] row = { $"{lbl}", $"{x.x}" , $"{x.y}" , $"{x.delay}", $"{clickType}", $"{md}" };
            var listItem = new ListViewItem(row);
            listItem.Tag = x;
            positionList.Items.Add(listItem);
        }

        /// <summary>
        /// Delete single row item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (positionList.Items.Count == 0 || positionList.SelectedItems.Count == 0) return;
            var selectedItem = positionList.SelectedItems[0];
            var item = selectedItem.Tag;
            if (item != null)
            {
                var pos = (MousePosition)item;
                PositionHelper.removeItem(pos.id);
                positionList.Items.Remove(selectedItem);
            }
        }

        /// <summary>
        /// Begin key and mouse recording
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beginMouseRecording_Click(object sender, EventArgs e)
        {
            recordButtonClickAction(false);
        }

        /// <summary>
        /// Start / Stop mouse click recording.
        /// Hooks / Un-hooks mouse
        /// </summary>
        /// <param name="isKeyPress"></param>
        private void recordButtonClickAction(bool isKeyPress)
        {
            if (!recordBtnEnabled || isModalOpen) return;
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
                Thread.Sleep(1);
                if (!isKeyPress)
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
            string sText = "";
            int dly = (int)timer.ElapsedMilliseconds - lastElapsedTime;
            lastElapsedTime = (int)timer.ElapsedMilliseconds;

            if (dly <= 2)
            {
                return; 
            }

            int x = e.Location.X;
            int y = e.Location.Y;
            bool isRightClk = true;
            Key? modifierKey = null;
            string modStr = "";
            bool isModified = false;

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (e.Button == MouseButtons.Left)
                {
                    sText = "(" + e.X.ToString() + "," + e.Y.ToString() + ")";
                    isRightClk = false;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    sText = "(" + e.X.ToString() + "," + e.Y.ToString() + ")";
                    isRightClk = true;
                }

                if (currentKeyPressed.HasValue)
                {
                    modifierKey = currentKeyPressed.Value;
                    modStr = modifierKey.ToString();
                    isModified = true;
                }

                var mp = new MousePosition(sText, x, y, dly, isRightClk, false,
                    convertKeyCode(modifierKey), modifierKey, isModified);
                PositionHelper.addItem(mp);
                appendClickPositionLabel(mp, modStr);
            }
        }

        private static VirtualKeyCode? convertKeyCode(Key? code)
        {
            if (!code.HasValue) return null;
            return (VirtualKeyCode)KeyInterop.VirtualKeyFromKey(code.Value);
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

        private static Keys? KeyToKeys(Key? key) => key switch
        {
            Key.LeftShift => Keys.LShiftKey,
            Key.LeftAlt => Keys.Alt,
            Key.LeftCtrl => Keys.LControlKey,
            _ => null,
        };

        private static KeyCode? KeyToKeyCode(Key? key) => key switch
        {
            Key.LeftShift => KeyCode.SHIFT,
            Key.RightShift => KeyCode.SHIFT,
            Key.LeftAlt => KeyCode.ALT,
            Key.RightAlt => KeyCode.ALT,
            Key.LeftCtrl => KeyCode.CONTROL,
            Key.RightCtrl => KeyCode.CONTROL,
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
                currIndex = 0;
                PositionHelper.positions.Clear();
                positionList.Items.Clear();
            }
        }

        private void repeatFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            repeatCount.Visible = false;
            repeatSelection.Visible = false;
            repeatLoopCountLabel.Visible = false;
            repeatLoopCount.Visible = false;
            hrLbl.Visible = false;
            mnLbl.Visible = false;
            scLbl.Visible = false;
            hrSelect.Visible = false;
            mnSelect.Visible = false;
            scSelect.Visible = false;

            if (string.Equals(repeatFor.Text, forNumberOfLoops, StringComparison.OrdinalIgnoreCase))
            {
                repeatLoopCountLabel.Text = "Total Loops: ";
                repeatLoopCountLabel.Visible = true;
                repeatLoopCount.Visible = true;
            }
            else if (string.Equals(repeatFor.Text, forNumberOfClicks, StringComparison.OrdinalIgnoreCase))
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
            var csss = (Key)startStopSelect.SelectedItem;
            if (csss == customRecord)
            {
                MessageBox.Show("You're already using this key for the record button, please choose another.", "Warning");
                startStopSelect.SelectedItem = customStartStop;
                startStopSelect.Text = customStartStop.ToString();
                return;
            }
            customStartStop = csss;
            Console.WriteLine("key / mouse: " + customStartStop.ToString());
            updateStartStopLabels(customStartStop.ToString());
        }

        private void customRecordBtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            var crb = (Key)customRecordBtn.SelectedItem;
            if (crb== customStartStop)
            {
                MessageBox.Show("You're already using this key to start and stop, please choose another.", "Warning");
                customRecordBtn.SelectedItem = customRecord;
                customRecordBtn.Text = customRecord.ToString();
                return;
            }
            customRecord = crb;
            Console.WriteLine("record btn: " + customRecord.ToString());
            updateRecordLabels(customRecord.ToString());
        }

        private void updateStartStopLabels(String keyLbl)
        {
            enableStartStopBtn.Text = $"Enable {keyLbl} Start / Stop";
            topLabel.Text = $"{keyLbl} to start and stop";
            startBtnTxt = $"Start ({keyLbl})";
            stopBtnTxt = $"Stop ({keyLbl})";
            updateBtnColorAndText();
        }

        private void updateRecordLabels(String keyLbl)
        {
            recordBtnOffTxt = $"Start Recording ({customRecord})";
            recordBtnOnTxt = $"Stop Recording ({customRecord})";
            beginMouseRecording.Text = recordBtnOffTxt;
        }

        private void globalModifierKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            globalModifier = (Key)globalModifierKey.SelectedItem;
        }

        private void useGlobalModifier_CheckedChanged(object sender, EventArgs e)
        {
            globalModifierEnabled = (bool)useGlobalModifier.Checked;
        }

        private void enableRecordBtn_CheckedChanged(object sender, EventArgs e)
        {
            recordBtnEnabled = enableRecordBtn.Checked;
        }

        /// <summary>
        /// Save the list of click data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "dat";
            saveFileDialog1.Title = "Save Clicks";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                var bytes = ObjectArrayToByteArray(PositionHelper.positions);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
        }

        private OpenFileDialog ofd;

        /// <summary>
        /// Load a saved click file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Data files (*.dat)|*.dat",
                Title = "Open text file"
            };
        }

        private void globalDelayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            globalDelayEnabled = globalDelayCheckBox.Checked;
        }

        private void globalDelay_ValueChanged(object sender, EventArgs e)
        {
            globalDelayValue = Convert.ToInt32(globalDelay.Value);
        }

        private void loadFile(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = ofd.FileName;
                    var bytes = File.ReadAllBytes(filePath);
                    var res = ByteArrayToObjectArray(bytes);

                    var ps = (List<MousePosition>)res;
                    PositionHelper.positions.Clear();
                    PositionHelper.positions = ps;
                    updatePositions();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private byte[] ObjectArrayToByteArray<T>(List<T> positions)
        {
            if (positions == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, positions);
            return ms.ToArray();
        }

        // Convert a byte array to an Object
        private Object ByteArrayToObjectArray(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
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
