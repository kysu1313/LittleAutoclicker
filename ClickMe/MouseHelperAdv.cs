using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClickMe
{
    public class MouseHelperAdv
    {

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        public const int INPUT_KEYBOARD = 1;

        public const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        public const int KEYEVENTF_KEYUP = 0x0002;
        public const int KEYEVENTF_UNICODE = 0x0004;
        public const int KEYEVENTF_SCANCODE = 0x0008;

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public int type;
            public INPUTUNION inputUnion;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct INPUTUNION
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SendInput(int nInputs, [MarshalAs(UnmanagedType.LPArray)] INPUT[] pInput, int cbSize);

        public static void SendKey(short wVk, int nSleep, bool bExtendedkey, bool bDown, bool bUp)
        {
            INPUT[] input = new INPUT[1];
            if (bDown)
            {
                input[0].inputUnion.ki.wVk = wVk;
                input[0].inputUnion.ki.wScan = (short)MapVirtualKey((uint)wVk, 0);
                input[0].inputUnion.ki.dwFlags = KEYEVENTF_SCANCODE;
                if (bExtendedkey)
                    input[0].inputUnion.ki.dwFlags |= KEYEVENTF_EXTENDEDKEY;
                input[0].inputUnion.ki.time = 0;
                input[0].type = INPUT_KEYBOARD;
                SendInput(1, input, Marshal.SizeOf(input[0]));
                System.Threading.Thread.Sleep(nSleep);
            }

            if (bUp)
            {
                input[0].inputUnion.ki.wVk = wVk;
                input[0].inputUnion.ki.wScan = (short)MapVirtualKey((uint)wVk, 0);
                input[0].inputUnion.ki.dwFlags = KEYEVENTF_SCANCODE | KEYEVENTF_KEYUP;
                if (bExtendedkey)
                    input[0].inputUnion.ki.dwFlags |= KEYEVENTF_EXTENDEDKEY;
                input[0].inputUnion.ki.time = 0;
                input[0].type = INPUT_KEYBOARD;
                SendInput(1, input, Marshal.SizeOf(input[0]));
                System.Threading.Thread.Sleep(nSleep);
            }
        }

    }
}
