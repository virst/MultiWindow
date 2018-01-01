using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static MultiWindow.WindowUtils;

namespace MultiWindow
{
    class DesctopController
    {
        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        public string[] DescNames { private set; get; }
        int CurDesc = 0;
        public WindowsList windows = new WindowsList();

        public DesctopController() :this(4)
        { }

        public DesctopController(int d)
        {
            DescNames = new string[d];
            for (int i = 0; i < d; i++)
                DescNames[i] = "Рабочий стол " + (i + 1);
        }

        public void UpdateWindos()
        {
            foreach (var w in windows)
                w.deletebel = true;

            EnumWindows((hWnd, lParam) => {
                if (IsWindowVisible(hWnd) && GetWindowTextLength(hWnd) != 0)
                {
                    if (windows.IsHasNum(hWnd))
                        windows[hWnd].deletebel = false;
                    else
                        windows.Add( new WindowInfo(hWnd) { DescNum = CurDesc});

                }
                return true;
            }, IntPtr.Zero);

            for(int i=0;i<windows.Count;i++)
            {
                
                    if (windows[i].deletebel)
                        windows.RemoveAt(i--);
                
            }
        }
    }


}
