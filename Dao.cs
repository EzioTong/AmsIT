using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AmsIT
{
    class Dao
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            string str = @"Data Source = LAPTOP-MH2TVGID; Initial Catalog = AmsIT; Integrated Security = True";
            SqlConnection sc = new SqlConnection(str);
            sc.Open();
            return sc;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql)          // update
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql)       //read
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose()      //close
        {
            sc.Close();
        }
    }
}
