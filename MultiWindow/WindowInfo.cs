using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static MultiWindow.WindowUtils;

namespace MultiWindow
{
    public class WindowInfo
    {
        public WindowInfo(IntPtr Wnd)
        {
            hWnd = Wnd;
            Text = GetWindowText(hWnd);
            defWindowsStyle = GetWindowLong(hWnd, WindowLongFlags.GWL_EXSTYLE);
        }


        public IntPtr hWnd;
        public string Text;
        internal WindowStylesEx defWindowsStyle;
        public int DescNum;
        public bool deletebel = false;

        static string GetWindowText(IntPtr hWnd)
        {
            int len = GetWindowTextLength(hWnd) + 1;
            StringBuilder sb = new StringBuilder(len);
            len = WindowUtils.GetWindowText(hWnd, sb, len);
            return sb.ToString(0, len);
        }

        public override string ToString()
        {
            return Text + "(" + DescNum +")";
        }
    }
}
