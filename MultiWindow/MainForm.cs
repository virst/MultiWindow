using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiWindow
{
    public partial class MainForm : Form
    {
        DesctopController dc = new DesctopController();

        public MainForm()
        {
            InitializeComponent();

           this.listBox1.DataSource = dc.windows;
            ucMyRadios1.Strings = dc.DescNames;

            
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            dc.UpdateWindos();            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = listBox1.SelectedItem as WindowInfo;
            if (i == null)
                return;
            try
            {
                ucMyRadios1.CheckedIndex = i.DescNum;
            }catch(Exception)
            {

            }
        }

        private void ucMyRadios1_CheckedIndesChanged(object sender, EventArgs e)
        {
            var i = listBox1.SelectedItem as WindowInfo;
            if (i == null || i.DescNum == ucMyRadios1.CheckedIndex)
                return;
            i.DescNum = ucMyRadios1.CheckedIndex;
            dc.windows.ResetBindings();
        }
    }
}
