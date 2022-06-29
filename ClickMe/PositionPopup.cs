using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickMe
{
    public partial class PositionPopup : Form
    {
        private int? xP;
        private int? yP;
        private String label;
        private int? delay;

        public PositionPopup()
        {
            InitializeComponent();
        }

        private void PositionPopup_Load(object sender, EventArgs e)
        {
            popupBackgroundWorker.RunWorkerAsync();
        }

        private void popupBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (MouseHelper.GetAsyncKeyState(Keys.F7) < 0)
                {
                    xP = MousePosition.X;
                    yP = MousePosition.Y;
                    xValueLabel.Text = xP.ToString();
                    yValueLabel.Text = yP.ToString();
                }
                Thread.Sleep(1);
            }
        }

        private void positionLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (xP == null || yP == null)
            {
                popupWarning.Text = "Please set a cursor position";
                return;
            }

            if (String.IsNullOrEmpty(positionDelay.Text) || !int.TryParse(positionDelay.Text, out int dly))
            {
                popupWarning.Text = "Please set a click delay";
                return;
            }
            else
            {
                delay = dly;
            }

            if (String.IsNullOrEmpty(positionLabel.Text))
            {
                popupWarning.Text = "Please set a unique label";
                return;
            }
            label = positionLabel.Text;

            MousePosition mp = new MousePosition(label, (int)xP, (int)yP, (int)delay);
            if (PositionHelper.addItem(mp))
            {
                //popupBackgroundWorker.CancelAsync();
                this.Close();
                return;
            }

        }
    }
}
