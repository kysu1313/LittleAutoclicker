using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickMe
{
    public class ProcessHelper
    {

        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        //this is a constant indicating the window that we want to send a text message
        const int WM_SETTEXT = 0X000C;

        public static void SetActiveWindow(IntPtr windowHandle) => SetForegroundWindow(windowHandle);


        public static void ActivateApp(string processName)
        {
            Process[] p = Process.GetProcessesByName(processName);

            // Activate the first application we find with this name
            if (p.Count() > 0)
                SetForegroundWindow(p[0].MainWindowHandle);
        }

        public static void SetApp(Process p)
        {
            if (p == null) return;
            var pointer = p.Handle;
            SetForegroundWindow(pointer);
        }

        public static void SendKey(string key)
        {
            SendKeys.Send(key);
        }

        public static void SendWaitKey(string key)
        {
            SendKeys.SendWait(key);
        }

        public static void SendKeyPress(IntPtr windowHandle, string key)
        {
            SetForegroundWindow(windowHandle);
            System.Windows.Forms.SendKeys.Send(key);
        }

        //private void ActiveWindowChanged(object sender, ActiveWindowChangedEventArgs e)
        //{
        //    activeWindow = ActiveWindowModel.Create(e.WindowHandle, e.WindowTitle);
        //    lblCurrentlyActiveWindow.Text = $"Active Window: {e.WindowTitle}";
        //}

        public static void SendTestMsg(Process p)
        {

            SetActiveWindow(p.MainWindowHandle);
            SendKeyPress(p.MainWindowHandle, "k");

            Process[] notepads = Process.GetProcessesByName("notepad");
            IntPtr child = FindWindowEx(notepads[0].MainWindowHandle, new IntPtr(0), "Edit", null);
            SendMessage(child, 0x000C, 0, "testing");

            var a = "";
            //getting notepad's textbox handle from the main window's handle
            //the textbox is called 'Edit'
            IntPtr notepadTextbox = FindWindowEx(p.MainWindowHandle, IntPtr.Zero, "Edit", null);
            //sending the message to the textbox
            SendMessage(notepadTextbox, WM_SETTEXT, 0, "This is the new Text!!!");

        }

    }
}
