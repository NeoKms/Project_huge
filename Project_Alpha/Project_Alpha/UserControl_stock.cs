using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Alpha
{
    public partial class UserControl_stock : UserControl
    {
        public UserControl_stock()
        {
            InitializeComponent();
            for(int i=0; i < 30; i++)
            {
                dataGridView1.RowCount++;
                dataGridView1.Rows[i].Cells[0].Value = "Test" + (i + 1);
                dataGridView1.Rows[i].Cells[1].Value = (i*2);
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
