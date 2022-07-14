using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickMe.KeyboardFunctions
{
    public class ActiveWindowChangedEventArgs : EventArgs
    {
        public IntPtr WindowHandle { get; set; } = IntPtr.Zero;
        public string WindowTitle { get; set; } = string.Empty;

        public static ActiveWindowChangedEventArgs Create(string windowTitle, IntPtr windowHandle) =>
            new ActiveWindowChangedEventArgs() { WindowTitle = windowTitle, WindowHandle = windowHandle };
    }
}
