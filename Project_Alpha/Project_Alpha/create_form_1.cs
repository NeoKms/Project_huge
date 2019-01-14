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
    public partial class create_form_1 : Form
    {
        Form pred_form;
        int id_work = 0,id_facroty=0;
        bool create;
        UserControl_spec spec;
        UserControl_post_ post;
        UserControl_stock stock;
        public create_form_1(Form pred_f,int id,int id2, bool create_no)
        {
            InitializeComponent();
            now_but_act = this.button1;
            create = create_no;
            pred_form = pred_f;
            id_work = id;
            id_facroty = id2;
            spec = new UserControl_spec(id_facroty,create);
            post = new UserControl_post_(id_facroty, create);
            stock = new UserControl_stock(id_facroty, create);
            this.panel1.Controls.Add(spec);
            Size si = new Size(942, 473);
            this.Size = si;
            now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_active;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void create_form_1_Load(object sender, EventArgs e)
        {

        }

        private void create_form_1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bt6)
            {
                pred_form.Show();
            }
            else
            {
                pred_form.Close();
            }
        }
        Button now_but_act;
        
        private void button1_Click(object sender, EventArgs e)
        {
            now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_unactive;
            now_but_act = this.button1;
            this.now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_active;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(spec);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_unactive;
            now_but_act = this.button2;
            this.now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_active;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(stock);
        }
        bool bt6 = false;
        private void button6_Click(object sender, EventArgs e)
        {
            bt6 = true;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.No)
            {
                string connStr = "server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root";
                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlCommand cmd = new MySqlCommand();
                if (create)
                {
                    cmd.CommandText = "UPDATE factories set date_create=?date, name=?names, president_name=?pres_name, president_secons_name=?pres_s_name,col_workers=?work where ID_factory=?fact";
                    cmd.Parameters.Add("?names", MySqlDbType.VarChar).Value = spec.get_name();
                    DateTime now = DateTime.Now;
                    cmd.Parameters.Add("?date", MySqlDbType.DateTime).Value = now.ToString("yyyy/MM/dd HH:mm:ss");
                    cmd.Parameters.Add("?pres_name", MySqlDbType.VarChar).Value = spec.get_pres_name();
                    cmd.Parameters.Add("?pres_s_name", MySqlDbType.VarChar).Value = spec.get_pres_s_name();
                    cmd.Parameters.Add("?work", MySqlDbType.Int32).Value = stock.get_col_work();
                    cmd.Parameters.Add("?fact", MySqlDbType.VarChar).Value = id_facroty;
                    try
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                conn.Close();
                stock.refresh_stock(spec.get_spec());
                post.refresh_post();
                this.Close();
            }
            bt6 = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_unactive;
            now_but_act = this.button3;
            this.now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_active;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(post);
        }
    }
}
