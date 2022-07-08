using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickMe
{
    public class PositionHelper
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

        public static void updateItem(MousePosition pos)
        {
            var cur = positions.FirstOrDefault(x => x.id == pos.id);
            if (cur != null)
            {
                cur.x = pos.x;
                cur.y = pos.y;
                cur.delay = pos.delay;
                cur.label = pos.label;
                cur.isDoubleClick = pos.isDoubleClick;
                cur.isRightClick = pos.isRightClick;
                cur.modifier = pos.modifier;
                cur.useModifier = pos.useModifier;
            }
        }
    }
}
