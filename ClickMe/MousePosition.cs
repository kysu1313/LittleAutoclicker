using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsInput.Native;
using static ClickMe.KeyCodes;

namespace ClickMe
{
    public class MousePosition
    {
        public String label;
        public int x;
        public int y;
        public int delay;
        public bool isRightClick;
        public bool isDoubleClick;
        public bool useModifier;
        public VirtualKeyCode? modifier;

        public MousePosition(String label, int x, int y, int delay, 
            bool isRightClick, bool isDoubleClick, VirtualKeyCode? modifier, bool useModifier = false)
        {
            this.label = label;
            this.x = x;
            this.y = y;
            this.delay = delay;
            this.isRightClick = isRightClick;
            this.isDoubleClick = isDoubleClick;
            this.modifier = modifier;
            this.useModifier = useModifier;
        }
    }
}
