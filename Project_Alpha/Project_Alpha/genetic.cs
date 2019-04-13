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
    public partial class genetic : Form
    {
        public genetic()
        {
            InitializeComponent();
            Genetic_Algorithm ALG_1_test = new Genetic_Algorithm();
           ALG_1_test.Create_population(5);
            ALG_1_test.get_text(this.richTextBox1);
            
        }

        private void genetic_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
