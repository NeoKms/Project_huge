using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Alpha
{
    public partial class create_form_1 : Form
    {
        Form pred_form;
        int id_work = 0;
        UserControl_spec spec = new UserControl_spec();
        public create_form_1(Form pred_f,int id)
        {
            InitializeComponent();
            pred_form = pred_f;
            id_work = id;
            this.panel1.Controls.Add(spec);
            Size si = new Size(942, 473);
            this.Size = si;

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(spec);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
        }
        bool bt6 = false;
        private void button6_Click(object sender, EventArgs e)
        {
            bt6 = true;
            this.Close();
        }
    }
}
