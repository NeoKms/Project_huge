using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Project_Alpha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                this.label1.Text = "Connecting to server...";
                conn.Open();
                string sql = "SELECT login, password FROM login";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr[0].ToString() == this.textBox1.Text && rdr[1].ToString() == this.textBox2.Text){
                        this.label1.Text = "Done";
                    }
                    else
                    {
                        this.label1.Text = "Login or password not correct. Retry again.";
                    }
                }
                rdr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
           //this.label1.Text = "Done.";

        }
    }
}
