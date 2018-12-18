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
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT login, password, ID_worker, ID_factory FROM login";
                cmd.Connection = conn;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr[0].ToString() == this.textBox1.Text && rdr[1].ToString() == this.textBox2.Text){
                        this.label1.Text = "Done";
                        int id_worker = Convert.ToInt32(rdr[2]);
                        int id_factory= Convert.ToInt32(rdr[3]);
                        DateTime now = DateTime.Now;
                        cmd.CommandText = "INSERT INTO `project_1`.`logs` (`time_when`, `ID_worker`, `ID_factory`) VALUES (\'" + now.ToString("yyyy/MM/dd HH:mm:ss") + "\', \'" + id_worker + "\', \'" + id_factory + "\');";
                        rdr.Close();
                        cmd.ExecuteNonQuery();
                        this.Hide();
                        Select_factories form = new Select_factories(this, id_worker);
                        form.Show();
                        break;
                    }
                    else
                    {
                        this.label1.Text = "Login or password not correct. Retry again.";

                    }
                }
                if (!rdr.IsClosed) {
                    rdr.Close(); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
           

        }
        private void Closing_win(object sender, EventArgs e)
        {
            //MessageBox.Show("dg");
            //e.Cancel = true;
        }
    }
}
