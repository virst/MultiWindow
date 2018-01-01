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
    public partial class ucMyRadios : UserControl
    {
        public ucMyRadios()
        {
            InitializeComponent();
        }

        string[] _strings;

        public string[] Strings
        {
            get { return _strings; }
            set
            {
                _strings = value;
                this.Controls.Clear();
                foreach (var s in value)
                {
                    var t = new ucMyRadio();
                    t.Text = s;
                    t.Parent = this;
                    t.Dock = DockStyle.Top;
                }
            }
        }
    }
}
