using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Project_Alpha
{
    public partial class UserControl_stock : UserControl
    {
        public int get_col_work()
        {
            return Convert.ToInt32(this.textBox1.Text);
        }
        public void refresh_stock(bool[] matrix_spec)
        {
            string connStr = "server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select max(ID_item) from stock_in_factory";
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                int max_ID = Convert.ToInt32(rdr[0]);
                rdr.Close();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    max_ID++;
                    cmd.CommandText = "INSERT INTO stock_in_factory (ID_item, col_item, weigth, heigth, length, width, ID_factory, type_equipment) VALUES ("+ Convert.ToInt32(max_ID)+", "+ Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value)+", '0', '0', '0', '0', "+ Convert.ToInt32(id_fac_true)+",'"+ dataGridView1.Rows[i].Cells[0].Value.ToString()+"')";
                    cmd.ExecuteNonQuery();
                }
                if (matrix_spec[0])
                {
                    max_ID++; 
                    cmd.CommandText = "INSERT INTO stock_in_factory (ID_item, col_item, weigth, heigth, length, width, ID_factory, type_equipment) VALUES (" + Convert.ToInt32(max_ID) + ",'0', '0', '0', '0', '0', " + Convert.ToInt32(id_fac_true) + ",'Buckler body')";
                }
                if (matrix_spec[3])
                {
                    max_ID++; 
                    cmd.CommandText = "INSERT INTO stock_in_factory (ID_item, col_item, weigth, heigth, length, width, ID_factory, type_equipment) VALUES (" + Convert.ToInt32(max_ID) + ",'0', '0', '0', '0', '0', " + Convert.ToInt32(id_fac_true) + ",'Tanker hull')";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }
        int id_facroty = 0, end_id = 0,id_fac_true;
        bool create;
        public UserControl_stock(int id_fac,bool create_no)
        {
            InitializeComponent();
            create = create_no;
            if (!create)
            {
                id_facroty = id_fac;
            }
            id_fac_true = id_fac;
            string connStr = "server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT type_equipment,col_item,ID_item FROM stock_in_factory WHERE ID_factory=0 and ID_item!=4 and ID_item!=5";
                cmd.Connection = conn;
                MySqlDataReader rdr = cmd.ExecuteReader();
                int i = 0;
                while (rdr.Read())
                {
                    dataGridView1.RowCount++;
                    dataGridView1.Rows[i].Cells[0].Value = rdr[0];
                    dataGridView1.Rows[i].Cells[1].Value = rdr[1];
                    i++;
                }
                end_id = Convert.ToInt32(rdr[2]);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             for (int i=0; i< dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[1].Value = 20;
            }
        }
    }
}
