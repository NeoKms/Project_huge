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
    public partial class Select_factories : Form
    {
        Form login_form;
        int id_authorize_worker;
        public Select_factories(Form pred_form,int id_worker)
        {
            login_form = pred_form;
            id_authorize_worker = id_worker;
            InitializeComponent();


        }

        private void Select_factories_Load(object sender, EventArgs e)
        {

        }


        private void Select_factories_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save_slots form_slots = new Save_slots(this,login_form,id_authorize_worker,true);
            this.Hide();
            form_slots.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save_slots form_slots = new Save_slots(this, login_form, id_authorize_worker,false);
            form_slots.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        bool bt3 = false;
        private void button3_Click(object sender, EventArgs e)
        {
            bt3 = true;
            this.Close();
            
        }

        private void Select_factories_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (bt3)
            {
                login_form.Show();
            }
            else
            {
                login_form.Close();
            }

        }
    }
}
