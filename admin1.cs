using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmsIT
{
    public partial class admin1 : Form
    {
        public admin1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin2 admin = new admin2();
            admin.ShowDialog();
        }
    }
}
