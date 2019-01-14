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
        bool create;
        public Save_slots(Form pred_form, Form login_forms,  int id_worker, bool new_no)
        {
            select_factory_form = pred_form;
            login_form = login_forms;
            id_authorize_worker = id_worker;
            create = new_no;
            InitializeComponent();
        }
        bool fac1, fac2, fac3;
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
                            fac1 = false;
                            if (!create)
                            {
                                button1.Enabled = false;
                            }
                            this.button1.Text = "Пустой слот";
                            this.button1.BackgroundImage= global::Project_Alpha.Properties.Resources.red_plus_02;
                        }
                        else
                        {
                            fac1 = true;
                            if (create)
                            {
                                button1.Enabled = false;
                            }
                            this.button1.Text = rdr[1].ToString();
                            this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                            this.button1.BackgroundImage = global::Project_Alpha.Properties.Resources.factories_1;
                        }
                    }
                    if (Convert.ToInt32(rdr[0]) == 2)
                    {
                        if (rdr[1].ToString() == "empty")
                        {
                            if (!create)
                            {
                                button2.Enabled = false;
                            }
                            fac2 = false;
                            this.button2.Text = "Пустой слот";
                            this.button2.BackgroundImage = global::Project_Alpha.Properties.Resources.red_plus_02;
                        }
                        else
                        {
                            fac2 = true;
                            if (create)
                            {
                                button2.Enabled = false;
                            }
                            this.button2.Text = rdr[1].ToString();
                            this.button2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                            this.button2.BackgroundImage = global::Project_Alpha.Properties.Resources.factories_2;
                        }
                    }
                    if (Convert.ToInt32(rdr[0]) == 3)
                    {
                        if (rdr[1].ToString() == "empty")
                        {
                            if (!create)
                            {
                                button3.Enabled = false;
                            }
                            fac3 = false;
                            this.button3.Text = "Пустой слот";
                            this.button3.BackgroundImage = global::Project_Alpha.Properties.Resources.red_plus_02;
                        }
                        else
                        {
                            fac3 = true;
                            if (create)
                            {
                                button3.Enabled = false;
                            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!fac1)
            {
                create_form_1 form = new create_form_1(this, id_authorize_worker,1,create);
                form.Show();
            }
            else
            {
                Factory_control_center f_c_C = new Factory_control_center(this,1,id_authorize_worker);
                f_c_C.Show();
                this.Hide();
            }
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!fac2)
            {
                create_form_1 form = new create_form_1(this, id_authorize_worker, 2, create);
                form.Show();
            }
            else
            {
                Factory_control_center f_c_C = new Factory_control_center(this, 2,id_authorize_worker);

                f_c_C.Show();
                this.Hide();
            }
            this.Hide();
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
            if (!fac3)
            {
                create_form_1 form = new create_form_1(this, id_authorize_worker, 2,create);
                form.Show();
            }
            else
            {
                Factory_control_center f_c_C = new Factory_control_center(this, 3,id_authorize_worker);
                f_c_C.Show();
                this.Hide();
            }
            this.Hide();
        }
    }
}
