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
        Form select_factory_form, login_form;
        int id_authorize_worker;
        public Save_slots(Form pred_form, Form login_forms,  int id_worker)
        {
            select_factory_form = pred_form;
            login_form = login_forms;
            id_authorize_worker = id_worker;
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
                            this.button1.Text = "Пустой слот";
                            this.button1.BackgroundImage= global::Project_Alpha.Properties.Resource.red_plus_02;
                        }
                        else
                        {
                            this.button1.Text = rdr[1].ToString();
                            this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                            this.button1.BackgroundImage = global::Project_Alpha.Properties.Resource.factories_1;
                        }
                    }
                    if (Convert.ToInt32(rdr[0]) == 2)
                    {
                        if (rdr[1].ToString() == "empty")
                        {
                            this.button2.Text = "Пустой слот";
                            this.button2.BackgroundImage = global::Project_Alpha.Properties.Resource.red_plus_02;
                        }
                        else
                        {
                            this.button2.Text = rdr[1].ToString();
                            this.button2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                            this.button2.BackgroundImage = global::Project_Alpha.Properties.Resource.factories_2;
                        }
                    }
                    if (Convert.ToInt32(rdr[0]) == 3)
                    {
                        if (rdr[1].ToString() == "empty")
                        {
                            this.button3.Text = "Пустой слот";
                            this.button3.BackgroundImage = global::Project_Alpha.Properties.Resource.red_plus_02;
                        }
                        else
                        {
                            this.button3.Text = rdr[1].ToString();
                            this.button3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                            this.button3.BackgroundImage = global::Project_Alpha.Properties.Resource.factories_3;
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

        private void button1_Click(object sender, EventArgs e)
        {
            create_form_1 form = new create_form_1(this,id_authorize_worker);
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        bool bt4 = false;
        private void button4_Click(object sender, EventArgs e)
        {
            bt4 = true;
            this.Close();
        }

        private void Save_slots_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bt4){
                select_factory_form.Show();
            }
            else
            {
                select_factory_form.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
