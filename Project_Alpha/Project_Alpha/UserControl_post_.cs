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
    public partial class UserControl_post_ : UserControl
    {
        public void refresh_post()
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
                for (int i = 0; i < col; i++)
                {
                    cmd.CommandText = "INSERT INTO suppliers_in_factory (ID_factory, ID_item, ID_supplier) VALUES ("+ Convert.ToInt32(id_fact)+ ","+Convert.ToInt32(matr_post[i, 0]) + ", "+ Convert.ToInt32(matr_post[i, 1]) + ")";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }
        private int id_facroty = 0, id_fact = 0, col = 0;
        private bool create;
        private Label[] matr_lable;
        private  CheckBox[] matr_check;
        public int[,] matr_post;
        private CheckBox now_check;
        private Label now_label;
        public UserControl_post_(int id_fac,bool create_no)
        {
            InitializeComponent();
            id_fact = id_fac;
            create = create_no;
            if (!create)
            {
                id_facroty = id_fac;
            }
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 0;
            string connStr = "server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                int i = 0;
                cmd.Connection = conn;
                cmd.CommandText = "SELECT count(*) FROM stock_in_factory WHERE ID_factory="+ id_facroty+" and ID_item!=4 and ID_item!=5";
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                col = Convert.ToInt32(rdr[0]);
                rdr.Close();
                cmd.CommandText = "SELECT type_equipment,ID_item FROM stock_in_factory WHERE ID_factory=" + id_facroty + " and ID_item!=4 and ID_item!=5";
                rdr = cmd.ExecuteReader();
                tableLayoutPanel1.RowCount = col;
                matr_lable = new Label[col];
                matr_check = new CheckBox[col];
                matr_post = new int[col,2];
                while (rdr.Read())
                {
                    RowStyle style = new RowStyle(SizeType.AutoSize);
                    tableLayoutPanel1.RowStyles.Add(style);
                    matr_lable[i] = new Label();
                    matr_lable[i].Click += label__Click;
                    matr_lable[i].Name = "LabelTab_" + (i + 1);
                    matr_check[i] = new CheckBox();
                    matr_check[i].Name = "CheckTab_" + (i + 1);
                    matr_check[i].Enabled = false;
                    matr_lable[i].Text = Convert.ToString(rdr[0]);
                    matr_lable[i].Width = 280;
                    matr_check[i].Text = Convert.ToString(rdr[1]);
                    tableLayoutPanel1.Controls.Add(matr_lable[i], 0, i);
                    tableLayoutPanel1.Controls.Add(matr_check[i], 1, i);
                    i++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
            this.tableLayoutPanel1.ColumnStyles[1].Width = 30;
            tableLayoutPanel1.Refresh();
        }
        private int now_id_item = 0;
        private void label__Click(object sender, EventArgs e)
        {
            now_label = sender as Label;
            string[] words = now_label.Name.Split(new char[] { '_' });
            now_id_item = Convert.ToInt32(matr_check[Convert.ToInt32(words[1]) - 1].Text);
            now_check = matr_check[Convert.ToInt32(words[1]) - 1];
            string connStr = "server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT organization FROM com_stock_suppliers, suppliers WHERE com_stock_suppliers.ID_supplier=suppliers.ID_supplier and com_stock_suppliers.ID_item=" + matr_check[Convert.ToInt32(words[1]) - 1].Text;
                cmd.Connection = conn;
                MySqlDataReader rdr = cmd.ExecuteReader();
                comboBox1.Items.Clear();
                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr[0]);

                }
                comboBox1.SelectedIndex = 0;
                comboBox1.Update();
                comboBox1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           string connStr = "server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
               cmd.CommandText = "SELECT the_cost, time_delivery FROM com_stock_suppliers WHERE com_stock_suppliers.ID_supplier=(Select ID_supplier from suppliers  where organization=\""+ comboBox1.Text+"\") and ID_item=" + now_id_item;
                cmd.Connection = conn;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    this.label4.Text = rdr[0].ToString()+" руб.";
                    this.label5.Text = rdr[1].ToString()+" (дней)";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            //string matrix = "";
            for (int i = 0; i < col; i++)
            {
                string str=matr_lable[i].Text, str2=matr_check[i].Text;
                matr_post[i, 0] = new int();
                matr_post[i, 1] = new int();
                matr_check[i].Checked = true;
                matr_post[i, 0] = Convert.ToInt32(str2);
                cmd.CommandText = "SELECT organization FROM com_stock_suppliers, suppliers WHERE com_stock_suppliers.ID_supplier=suppliers.ID_supplier and com_stock_suppliers.ID_item=" + matr_check[i].Text;
                try
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    string org = rdr[0].ToString();
                    rdr.Close();
                    cmd.CommandText = "Select ID_supplier from suppliers  where organization =\"" + org + "\"";
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    matr_post[i, 1] = Convert.ToInt32(rdr[0]);
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //matrix = matrix + matr_post[i, 0] + matr_post[i, 1] + "\n";
            }
            conn.Close();
           // MessageBox.Show(matrix);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int now_id_post = 0;
            string connStr = "server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Select ID_supplier from suppliers  where organization =\"" + comboBox1.Text + "\"";
                cmd.Connection = conn;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    now_id_post = Convert.ToInt32(rdr[0]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
            string[] words = now_label.Name.Split(new char[] { '_' });
            int num = Convert.ToInt32(words[1]) - 1;
            matr_check[num].Checked = true;
            matr_post[num,0] = new int();
            matr_post[num, 1] = new int();
            matr_post[num, 0] = now_id_item;
            matr_post[num,1] = now_id_post;

        }
    }
}
