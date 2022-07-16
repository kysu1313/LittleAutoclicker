using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;
using Xunit.Sdk;

namespace ClickMe
{
    
    public class ClickTests
    {

        [Fact]
        public void unpressKey()
        {
            Keys key = Keys.Shift;
            var keyByte = (byte)key;
            NativeMethods.keybd_event(keyByte, 0, 0x02, UIntPtr.Zero);
        }

    }
}
