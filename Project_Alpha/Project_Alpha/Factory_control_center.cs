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
    public partial class Factory_control_center : Form
    {
        Form pred_form;
        int id_factory, id_worker;
        public Factory_control_center(Form pred,int fac_id,int id_work)
        {
            InitializeComponent();
            id_worker = id_work;
            button1.Enabled = false;
            button3.Enabled = false;
            pred_form = pred;
            id_factory = fac_id;
            string connStr = "server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select name,president_name,president_secons_name from factories where ID_factory=" + id_factory;
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                label3.Text = rdr[0].ToString();
                label4.Text = rdr[1].ToString() + "  "+rdr[2].ToString();
                label6.Text = "Танкеры: Малотоннажный танкер";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Factory_control_center_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bt4)
            {
                pred_form.Show();
            }
            else
            {
                pred_form.Close();
            }
        }
        bool bt4 = false;
        private void button4_Click(object sender, EventArgs e)
        {
            bt4 = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Factory_statistics fact = new Factory_statistics(this, id_factory);
            fact.ShowDialog();
          //  this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            create_form_1 form = new create_form_1(this, id_factory, id_worker, false);
            form.Show();
            this.Hide();
        }
    }
}
