using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MultiWindow.WindowUtils;

namespace MultiWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

             

        private void button1_Click(object sender, EventArgs e)
        {
            var wi = listBox1.SelectedItem as WindowInfo;

            var hWnd = wi.hWnd;
            var tmp = wi.defWindowsStyle;

            ShowWindow(hWnd, WindowShowStyle.Hide);
            SetWindowLong(hWnd, WindowLongFlags.GWL_EXSTYLE, WindowStylesEx.WS_EX_TOOLWINDOW );
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var wi = listBox1.SelectedItem as WindowInfo;

            var hWnd = wi.hWnd;
            var tmp = wi.defWindowsStyle;

            SetWindowLong(hWnd, WindowLongFlags.GWL_EXSTYLE, tmp);
            ShowWindow(hWnd, WindowShowStyle.Show);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
