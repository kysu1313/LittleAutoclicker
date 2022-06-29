using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickMe
{
    public class MousePosition
    {
        public String label;
        public int x;
        public int y;
        public int delay;

        public MousePosition(String label, int x, int y, int delay)
        {
            this.label = label;
            this.x = x;
            this.y = y;
            this.delay = delay;
        }
    }
}
