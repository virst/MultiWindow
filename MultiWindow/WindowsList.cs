using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiWindow
{
    class WindowsList : BindingList<WindowInfo>
    {
        public bool IsHasNum(IntPtr n)
        {
            foreach (var w in this)
                if (w.hWnd == n)
                    return true;
            return false;
        }

        public WindowInfo this[IntPtr n]
        {
            get
            {
                foreach (var w in this)
                    if (w.hWnd == n)
                        return w;
                return null;
            }
        }
    }
}
