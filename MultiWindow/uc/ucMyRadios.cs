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
        List<RadioButton> rbs = new List<RadioButton>();

        public string[] Strings
        {
            get { return _strings; }
            set
            {
                _strings = value;
                this.Controls.Clear();
                rbs.Clear();
                foreach (var s in value)
                {
                    var t = new ucMyRadio();
                    t.Text = s;
                    t.Parent = this;
                    t.Dock = DockStyle.Top;
                    rbs.Add(t.radioButton1);
                    t.radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
                    t.textBox1.TextChanged += TextBox1_TextChanged;
                    t.BringToFront();
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            _strings[this.Controls.IndexOf((sender as Control).Parent)] = (sender as TextBox).Text;
        }

        int ci = 0;

        public event EventHandler CheckedIndesChanged;

        public int CheckedIndex
        {
            get
            {
                return ci;
            }

            set
            {
                ci = value;
                if (ci < rbs.Count)
                    rbs[ci].Checked = true;
                CheckedIndesChanged?.Invoke(this, new EventArgs());
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;

            if (rb.Checked)
                for (int i = 0; i < rbs.Count; i++)
                {
                    var c = rbs[i];
                    if (c != rb)
                        c.Checked = false;
                    else CheckedIndex = i;
                }
        }
    }
}
