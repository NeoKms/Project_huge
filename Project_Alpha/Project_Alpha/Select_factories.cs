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
            login_form.Close();
        }
    }
}
