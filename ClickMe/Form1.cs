using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ClickMe
{

    public partial class Form1 : Form
    {


        private int currIndex;
        public int intervals = 500;
        public bool click = false;
        public int parsedValue = 1;
        public PositionHelper positionHelper = new PositionHelper();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                if (checkBox1.Checked && click)
                {
                    //MouseHelper.DoMouseClick();
                    executeClick(PositionHelper.positions[currIndex]);
                }
            }
        }

        private void executeClick(MousePosition mousePosition)
        {
            int xp = mousePosition.x;
            int yp = mousePosition.y;

            Console.WriteLine($"Move to: ({xp}, {yp}), with delay: {mousePosition.delay}");
            MouseHelper.POINT p = new MouseHelper.POINT(xp, yp);
            MouseHelper.ClientToScreen(Handle, ref p);
            MouseHelper.SetCursorPos(getRandInt(xp), getRandInt(yp));
            MouseHelper.DoMouseClick();

            ++currIndex;
            if (currIndex >= PositionHelper.positions.Count)
            {
                currIndex = 0;
            }

            Thread.Sleep(mousePosition.delay);
            
        }

        private int getRandInt(int pt)
        {
            if (randomizeDelays.Checked)
            {
                int seed = 10;
                if (!String.IsNullOrEmpty(rangePercentDropdown.SelectedItem.ToString()))
                {
                    int.TryParse(rangePercentDropdown.SelectedItem.ToString(), out seed);
                }
                Random rnd = new Random();
                int rand = rnd.Next(seed);
                bool addOrSub = rnd.Next(100) > 50;

                if (addOrSub)
                {
                    pt += rand;
                }
                else
                {
                    pt -= rand;
                }
            }
            return pt;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                if (MouseHelper.GetAsyncKeyState(Keys.F6) < 0)
                {
                    click = !click;

                }
                Thread.Sleep(1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int parsedValue))
            {
                MessageBox.Show("Please enter a number");
            }
            else
            {
                intervals = parsedValue;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void positionList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addRowBtn_Click(object sender, EventArgs e)
        {
            var formPopup = new PositionPopup();
            formPopup.FormClosing += new FormClosingEventHandler(onPopupClose);
            formPopup.Show(this);
        }

        private void positionList_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        public void onPopupClose(object sender, FormClosingEventArgs e)
        {
            positionList.Items.Clear();
            if (PositionHelper.positions.Count > 0)
            {
                PositionHelper.positions.ForEach(x =>
                {
                    String txt = $" - {x.label}, X: {x.x}, Y: {x.y}, Delay: {x.delay} (ms)";
                    positionList.Items.Add(txt);
                });
            }
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
    }
}
