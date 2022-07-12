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
    [Serializable]
    public class MousePosition
    {
        public Guid id;
        public String label;
        public int x;
        public int y;
        public int delay;
        public bool isRightClick;
        public bool isDoubleClick;
        public bool useModifier;
        public VirtualKeyCode? modifier;
        public bool isUpdate;
        public bool overrideGlobalDelay;

        public MousePosition(String label, int x, int y, int delay, 
            bool isRightClick, bool isDoubleClick, VirtualKeyCode? modifier = null,
            Key? keyModifier = null, bool useModifier = false, bool isUpdate = false, bool overrideGlobalDelay = false)
        {
            this.id = Guid.NewGuid();
            this.label = label;
            this.x = x;
            this.y = y;
            this.delay = delay;
            this.isRightClick = isRightClick;
            this.isDoubleClick = isDoubleClick;
            this.modifier = modifier;
            this.useModifier = useModifier;
            this.isUpdate = isUpdate;
            this.overrideGlobalDelay = overrideGlobalDelay;
        }
    }
}
