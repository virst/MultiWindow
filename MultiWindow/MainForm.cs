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
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            dc.UpdateWindos();            
        }
    }
}
