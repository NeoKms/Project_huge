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

        int id_facroty = 0, end_id = 0;
        bool create;
        public UserControl_stock(int id_fac,bool create_no)
        {
            InitializeComponent();
            create = create_no;
            if (!create)
            {
                id_facroty = id_fac;
            }
    
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
