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
    public partial class Factory_statistics : Form
    {
        Form pred_form;
        int id_factory, id_worker;
        public Factory_statistics(Form pred,int id_fact)
        {
            InitializeComponent();
            pred_form = pred;
            id_factory = id_fact;
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
                label4.Text = rdr[1].ToString() + "  " + rdr[2].ToString();
                label6.Text = "Грузовые: Баклер";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Factory_statistics_Load(object sender, EventArgs e)
        {

        }
    }
}
