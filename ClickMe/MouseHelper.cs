using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClickMe.KeyCodes;

namespace ClickMe
{

    class MouseHelper
    {

        public static uint MOUSEEVENTF_LEFTDOWN = 0x02;
        public static uint MOUSEEVENTF_LEFTUP = 0x04;
        public static uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        public static uint MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("User32.Dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;

            public POINT(int X, int Y)
            {
                x = X;
                y = Y;
            }
        }

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        /// <summary>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);


        private void detectKeyDown(Keys key)
        {
            byte[] keys = new byte[255];

            GetKeyboardState(keys);

            if (keys[(int)key] == 129)
            {
                Console.WriteLine("Up Arrow key and Right Arrow key down.");
            }
        }

        public static void DoMouseClick(uint btnDown, uint btnUp)
        {
            var inputMouseDown = new INPUT();
            inputMouseDown.Type = 0; /// input type mouse
            inputMouseDown.Data.Mouse.Flags = btnDown; // 0x0002; /// left button down

            var inputMouseUp = new INPUT();
            inputMouseUp.Type = 0; /// input type mouse
            inputMouseUp.Data.Mouse.Flags = btnUp; // 0x0004; /// left button up

            var inputs = new INPUT[] { inputMouseDown, inputMouseUp };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
            Thread.Sleep(2);
        }

        public static void SendKeyDown(KeyCode keyCode)
        {
            INPUT input = new INPUT
            {
                Type = 1
            };
            input.Data.Keyboard = new KEYBDINPUT();
            input.Data.Keyboard.Vk = (ushort)keyCode;
            input.Data.Keyboard.Scan = 0;
            input.Data.Keyboard.Flags = 0;
            input.Data.Keyboard.Time = 0;
            input.Data.Keyboard.ExtraInfo = IntPtr.Zero;
            INPUT[] inputs = new INPUT[] { input };
            if (SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
            {
                throw new Exception();
            }
        }

        public static void DoMouseClick2()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        //public static void LinearSmoothMove(Point newPosition, int steps)
        //{
        //    Point start = GetCursorPosition();
        //    PointF iterPoint = start;

        //    // Find the slope of the line segment defined by start and newPosition
        //    PointF slope = new PointF(newPosition.X - start.X, newPosition.Y - start.Y);

        //    // Divide by the number of steps
        //    slope.X = slope.X / steps;
        //    slope.Y = slope.Y / steps;

        //    // Move the mouse to each iterative point.
        //    for (int i = 0; i < steps; i++)
        //    {
        //        iterPoint = new PointF(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
        //        SetCursorPosition(Point.Round(iterPoint));
        //        Thread.Sleep(MouseEventDelayMS);
        //    }

        //    // Move the mouse to the final destination.
        //    SetCursorPosition(newPosition);
        //}
    }
}