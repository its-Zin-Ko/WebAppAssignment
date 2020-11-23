using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AssignmentApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string connectionstring;
        MySqlConnection conn;
        MySqlCommand command;
        private void btn_search1_Click(object sender, EventArgs e)
        {
           
            connectionstring = string.Format("server=localhost;uid=root;pwd=;database=assignment");
            conn = new MySqlConnection(connectionstring);
            conn.Open();
           
            string query = "select * from movies";
            command = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(query, conn);
            DataTable dt;
            DataSet ds = new DataSet();
            DataRow dr;
            adapter.Fill(ds, "0");
            dt = ds.Tables["0"];
            dr = dt.Rows[0];
            dataGridView1.DataSource = ds.Tables["0"];
            command.Dispose();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            connectionstring = string.Format("server=localhost;uid=root;pwd=;database=assignment");
            conn = new MySqlConnection(connectionstring);
            conn.Open();

            string query = "select * from movies where Name='"+txt_search.Text+"'";
            command = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
