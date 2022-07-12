using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WindowsInput.Native;
using static ClickMe.KeyCodes;

namespace ClickMe
{
    public class FormHelper
    {

        public static int getClickDelay(MousePosition mp, bool enabled, int randomValue, 
            bool globalDelayEnabled, int globalDelay)
        {
            int dly = globalDelayEnabled ? mp.overrideGlobalDelay ? mp.delay : globalDelay : mp.delay;

            if (enabled)
            {
                var rand = new Random();
                var r = (double)rand.Next(randomValue);
                double num = r / 100;
                double res = dly * num;
                var bol = rand.Next(100);
                dly = (int)(bol > 50 ? dly + res : dly - res);
            }
            return dly;
        }

        /// <summary>
        /// Randomize the click positions by 'positionModifier' amount of pixels
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static (int, int) getRandIntTuple(int x, int y, bool enabled, decimal value)
        {
            if (enabled)
            {
                int seed = 2;
                if (value > 0)
                {
                    seed = Decimal.ToInt32(value);
                }
                Random rndX = new Random();
                Random rndY = new Random();
                int rx = rndX.Next(0, seed);
                int ry = rndX.Next(0, seed);
                bool xPos = rndX.Next(1, 10) > 5;
                bool yPos = rndY.Next(1, 10) > 5;
                rx = xPos ? rx : -rx;
                ry = yPos ? ry : -ry;

                Console.WriteLine($"Random Val, x: {rx}, y: {ry} ");

                return (x + rx, y + ry);
            }
            return (x, y);
        }

        public static byte[] ObjectArrayToByteArray<T>(List<T> positions)
        {
            if (positions == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, positions);
            return ms.ToArray();
        }

        // Convert a byte array to an Object
        public static Object ByteArrayToObjectArray(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
        }

        // Convert a key code to a virtual key code
        public static VirtualKeyCode? convertKeyCode(Key? code)
        {
            if (!code.HasValue) return null;
            return (VirtualKeyCode)KeyInterop.VirtualKeyFromKey(code.Value);
        }

        public static KeyCode? virtualKeyToKeyCode(VirtualKeyCode? key) => key switch
        {
            VirtualKeyCode.SHIFT => KeyCode.SHIFT,
            VirtualKeyCode.MENU => KeyCode.ALT,
            VirtualKeyCode.CONTROL => KeyCode.CONTROL,
            _ => null,
        };

        public static VirtualKeyCode? KeyToVirtualKeyCode(Key? key) => key switch
        {
            Key.LeftShift => VirtualKeyCode.SHIFT,
            Key.LeftAlt => VirtualKeyCode.MENU,
            Key.LeftCtrl => VirtualKeyCode.CONTROL,
            _ => null,
        };

        public static Keys? KeyToKeys(Key? key) => key switch
        {
            Key.LeftShift => Keys.LShiftKey,
            Key.LeftAlt => Keys.Alt,
            Key.LeftCtrl => Keys.LControlKey,
            _ => null,
        };

        public static KeyCode? KeyToKeyCode(Key? key) => key switch
        {
            Key.LeftShift => KeyCode.SHIFT,
            Key.RightShift => KeyCode.SHIFT,
            Key.LeftAlt => KeyCode.ALT,
            Key.RightAlt => KeyCode.ALT,
            Key.LeftCtrl => KeyCode.CONTROL,
            Key.RightCtrl => KeyCode.CONTROL,
            _ => null,
        };

    }
}
