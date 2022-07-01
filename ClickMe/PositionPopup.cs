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
using System.Windows.Input;
using WindowsInput.Native;
using static ClickMe.KeyCodes;

namespace ClickMe
{
    public partial class PositionPopup : Form
    {
        private int? xP;
        private int? yP;
        private String label;
        private int? delay;
        private int globalDelay;

        public PositionPopup(int globalDelay)
        {
            InitializeComponent();
            this.globalDelay = globalDelay;
        }

        private void PositionPopup_Load(object sender, EventArgs e)
        {
            popupBackgroundWorker.RunWorkerAsync();
            if (globalDelay != 0)
            {
                positionDelay.Text = globalDelay.ToString();
            }
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
            VirtualKeyCode? keyModifier = null;
            bool useModifier = false;

            if (xP == null || yP == null)
            {
                popupWarning.Text = "Please set a cursor position";
                return;
            }

            if (String.IsNullOrEmpty(positionDelay.Text))
            {
                if (globalDelay == 0)
                {
                    popupWarning.Text = "Please set a click delay";
                    return;
                }
                else
                {
                    delay = globalDelay;
                }
            }
            else
            {
                if (int.TryParse(positionDelay.Text, out int dly))
                {
                    delay = dly;
                }
                else
                {
                    if (globalDelay == 0)
                    {
                        popupWarning.Text = "Please set a click delay";
                        return;
                    }
                    else
                    {
                        delay = globalDelay;
                    }
                }
            }

            if (String.IsNullOrEmpty(positionLabel.Text))
            {
                popupWarning.Text = "Please set a unique label";
                return;
            }
            label = positionLabel.Text;

            if (clickModifier.SelectedItem != null &&
                !String.IsNullOrEmpty(clickModifier.SelectedItem.ToString()) &&
                !String.Equals(clickModifier.SelectedItem.ToString(), "None"))
            {
                var km = clickModifier.SelectedItem.ToString();
                var res = parseModifier(km);
                keyModifier = res.Item1;
                useModifier = res.Item2;
            }

            MousePosition mp = new MousePosition(label, (int)xP, (int)yP, (int)delay,
                rightClick.Checked, doubleClick.Checked, keyModifier, useModifier);
            if (PositionHelper.addItem(mp))
            {
                this.Close();
                return;
            }

        }

        private static (VirtualKeyCode?, bool) parseModifier(String name) => name switch
        {
            "Shift"     => (VirtualKeyCode.LSHIFT, true),
            "Alt"       => (VirtualKeyCode.LMENU, true),
            "Ctrl"      => (VirtualKeyCode.LCONTROL, true),
            _           => (null, false),
        };
    }
}
