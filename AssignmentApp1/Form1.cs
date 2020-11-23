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
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }
        void cleartextbox()
        {
            txt_name.Clear();
            txt_releasedate.Clear();
            txt_rating.Clear();
            txt_price.Clear();
            txt_director.Clear();
            txt_actor.Clear();
            txt_actress.Clear();
        }
        string connectionstring;
        MySqlConnection conn;
        MySqlCommand command;
        private void btn_insert_Click(object sender, EventArgs e)
        {
            string name, release_date, rating, director, actor, actress;
            int price;
            name = txt_name.Text;
            release_date = txt_releasedate.Text;
            rating = txt_rating.Text;
            price = int.Parse(txt_price.Text);
            director = txt_director.Text;
            actor = txt_actor.Text;
            actress = txt_actress.Text;

            connectionstring = string.Format("server=localhost;uid=root;pwd=;database=assignment");
            conn = new MySqlConnection(connectionstring);
            conn.Open();
            string query = "insert into movies values('" + name + "','" + release_date + "','" + rating + "','" + price + "','" + director + "','" + actor + "','" + actress + "')";
            command = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.InsertCommand = new MySqlCommand(query, conn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            MessageBox.Show("Data saved successfully");
            cleartextbox();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }
    }
}
