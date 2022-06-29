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
                    MouseHelper.DoMouseClick();
                    Thread.Sleep(intervals);
                }
            }
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
    }
}
