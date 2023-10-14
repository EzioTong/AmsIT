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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); //get id
        }

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string userperson = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string type = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string number = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                admin22edit admin22 = new admin22edit(id, name, userperson, type, number);
                admin22.ShowDialog();
                Table(); //refresh
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            admin22edit ade = new admin22edit();
            ade.ShowDialog();
        }

        private void admin2_Load(object sender, EventArgs e)
        {
            Table();
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); //get id
        }
        public void Table() // get data and display in table
        {
            dataGridView1.Rows.Clear(); //init
            Dao dao = new Dao();
            string sql = "select * from t_laptop";
            IDataReader dc = dao.read(sql);
            while(dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        // id search
        public void TableID() // get data and display in table
        {
            dataGridView1.Rows.Clear(); //init
            Dao dao = new Dao();
            string sql = $"select * from t_laptop where id = '{textBox1.Text}'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }        
        // name search
        public void TableName() // get data and display in table
        {
            dataGridView1.Rows.Clear(); //init
            Dao dao = new Dao();
            string sql = $"select * from t_laptop where name like '%{textBox2.Text}'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Log in successful!");
            admin21add ad = new admin21add();
            //this.Hide();
            ad.ShowDialog();
            //this.Show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                
                label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("Are you sure to delete this item?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(dr == DialogResult.OK)
                {
                    string sql = $"delete from t_book where id = '{id}'";
                    Dao dao = new Dao();
                    if(dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("Successfully deleted!");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete" + sql);
                    }
                    dao.DaoClose();
                }
            }
            catch
            {
                MessageBox.Show("Please select the item you want to delete!","Alert",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); //get id
        }

        private void idsearch_Click(object sender, EventArgs e)
        {
            TableID();
        }

        private void namesearch_Click(object sender, EventArgs e)
        {
            TableName();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Table();
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
