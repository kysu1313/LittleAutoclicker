using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsInput.Native;

namespace ClickMe
{
    public static class PositionHelper
    {

        public static List<MousePosition> positions = new List<MousePosition>();

        public static bool addItem(MousePosition pos)
        {
            MousePosition position = positions.Where(x => x.id == pos.id).FirstOrDefault();
            if (position != null)
                return false;
            positions.Add(pos);
            return true;
        }

        public static void removeItem(Guid id)
        {
            MousePosition pos = positions.Where(x => x.id == id).FirstOrDefault();
            if (pos != null)
                positions.Remove(pos);
        }

        public static void updateItem(MousePosition pos, String label, int x, int y, int delay,
            bool isRightClick, bool isDoubleClick, VirtualKeyCode? modifier = null,
            Key? keyModifier = null, bool useModifier = false, bool isUpdate = false, 
            bool overrideGlobalDelay = false, ProcessData process = null)
        {
            var cur = positions.FirstOrDefault(x => x.id == pos.id);
            if (cur != null)
            {
                cur.x = x;
                cur.y = y;
                cur.delay = delay;
                cur.label = label;
                cur.isDoubleClick = isDoubleClick;
                cur.isRightClick = isRightClick;
                cur.modifier = modifier ?? null;
                cur.useModifier = useModifier;
                cur.overrideGlobalDelay = overrideGlobalDelay;
                cur.process = process;
            }
        }
    }
}