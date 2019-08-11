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
            this.checkBox1.Checked = true;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
        }


        private void genetic_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        Genetic_Algorithm.Individ A = null;
        Genetic_Algorithm ALG_1_test = null;
        private void button1_Click(object sender, EventArgs e)
        {
            ALG_1_test = new Genetic_Algorithm();
            A=ALG_1_test.start_gen_alg(Convert.ToInt32(this.textBox1.Text), Convert.ToInt32(this.textBox2.Text), this.richTextBox1);
            this.button2.Enabled = true;
            this.button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ALG_1_test.text_jobs_in_stank(A, this.richTextBox1);
        }
    }
}
