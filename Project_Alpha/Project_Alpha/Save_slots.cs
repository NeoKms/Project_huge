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
    public partial class Save_slots : Form
    {
        public Save_slots()
        {
            InitializeComponent();
        }

        private void Save_slots_Load(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT ID_factory, name FROM factories";
                cmd.Connection = conn;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (Convert.ToInt32(rdr[0]) == 1)
                    {
                        if (rdr[1].ToString()=="empty")
                        {
                            this.button1.Text = "Пустой слот сохранения";
                            this.button1.BackgroundImage= global::Project_Alpha.Properties;
                        }
                        else
                        {
                            this.button1.Text = rdr[1].ToString();
                            this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                            this.button1.BackgroundImage = global::Project_Alpha.Properties.Resources.factories_1;
                        }
                    }
                    if (Convert.ToInt32(rdr[0]) == 2)
                    {
                        if (rdr[1].ToString() == "empty")
                        {
                            this.button2.Text = "Пустой слот сохранения";
                            this.button2.BackgroundImage = global::Project_Alpha.Properties.Resources.red_plus_02;
                        }
                        else
                        {
                            this.button2.Text = rdr[1].ToString();
                            this.button2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                            this.button2.BackgroundImage = global::Project_Alpha.Properties.Resources.factories_2;
                        }
                    }
                    if (Convert.ToInt32(rdr[0]) == 3)
                    {
                        if (rdr[1].ToString() == "empty")
                        {
                            this.button3.Text = "Пустой слот сохранения";
                            this.button3.BackgroundImage = global::Project_Alpha.Properties.Resources.red_plus_02;
                        }
                        else
                        {
                            this.button3.Text = rdr[1].ToString();
                            this.button3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                            this.button3.BackgroundImage = global::Project_Alpha.Properties.Resources.factories_3;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }
    }
}
