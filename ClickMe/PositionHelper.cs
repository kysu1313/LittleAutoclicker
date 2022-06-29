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
            MousePosition position = positions.Where(x => x.label == pos.label).FirstOrDefault();
            if (position != null)
                return false;
            positions.Add(pos);
            return true;
        }

        public static void removeItem(String label)
        {
            MousePosition pos = positions.Where(x => x.label == label).FirstOrDefault();
            if (pos != null)
                positions.Remove(pos);
        }
    }
}
