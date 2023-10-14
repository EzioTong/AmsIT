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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxUsername.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("Please insert again.");
            }
            
        }
        //log in verification, true means log in permitted
        public void Login()
        {
            if(radioButtonUser.Checked == true)
                //user
            {
                Dao dao = new Dao();
                //string sql3 = "select * from t_user where id = '" + textBoxUsername.Text + "' and psw = '" + textBoxPassword + "'";
                //string sql2 = String.Format("select * from t_user where id = '{0}' and psw = '{1}'", textBoxUsername.Text, textBoxPassword.Text);
                string sql = $"select * from t_user where id = '{textBoxUsername.Text}'and psw = '{textBoxPassword.Text}'";
                IDataReader dc = dao.read(sql);
                if(dc.Read())
                {
                    Data.UID = dc["id"].ToString();
                    Data.UName = dc["name"].ToString();
                    
                    MessageBox.Show("Log in successful!");
                    user1 user = new user1();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Log in failed!");
                }
                dao.DaoClose();
            }
            if(radioButtonAdmin.Checked == true)
                //admin
            {
                Dao dao = new Dao();
                //string sql3 = "select * from t_user where id = '" + textBoxUsername.Text + "' and psw = '" + textBoxPassword + "'";
                //string sql2 = String.Format("select * from t_user where id = '{0}' and psw = '{1}'", textBoxUsername.Text, textBoxPassword.Text);
                string sql = $"select * from t_admin where id = '{textBoxUsername.Text}'and psw = '{textBoxPassword.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("Log in successful!");
                    admin1 a = new admin1();
                    this.Hide();
                    a.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Log in failed!");
                }
                dao.DaoClose();
            }

        }
        

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
