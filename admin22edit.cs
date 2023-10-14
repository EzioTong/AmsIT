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
    public partial class admin22edit : Form
    {
        string ID = "";
        public admin22edit()
        {
            InitializeComponent();
        }
        public admin22edit(string id, string name, string userperson, string type, string number)
        {
            InitializeComponent();
            ID = textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = userperson;
            textBox4.Text = type;
            textBox5.Text = number;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update AmsIT.dbo.t_laptop set id = '{textBox1.Text}', [name] = '{textBox2.Text}', userperson = '{textBox3.Text}', type = '{textBox4.Text}', number = '{textBox5.Text}' where id = '{ID}'";
            Dao dao = new Dao();
            if(dao.Execute(sql) > 0)
            {
                MessageBox.Show("Edit successful!");
                this.Close();
            }
        }
    }
}
