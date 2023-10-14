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
    public partial class admin21add : Form
    {
        public admin21add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                Dao dao = new Dao();
                string sql = $"insert into t_laptop values('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}')";
                int n = dao.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("Successfully added!");
                }
                else
                {
                    MessageBox.Show("Failed add!");
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Empty insert!");
            }
            
        }
    }
}
