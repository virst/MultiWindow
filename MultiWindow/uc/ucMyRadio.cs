using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiWindow.uc
{
    public partial class ucMyRadio : UserControl
    {
        public ucMyRadio()
        {
            InitializeComponent();
        }

        public override string Text { get => textBox1.Text; set => textBox1.Text = value; }
    }
}
