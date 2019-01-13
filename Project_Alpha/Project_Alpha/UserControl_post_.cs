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
    public partial class UserControl_post_ : UserControl
    {
        public UserControl_post_()
        {
            InitializeComponent();
            int col = 30;
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.RowCount = col;
            Label[] matr_lable= new Label[col];
            CheckBox[] matr_check = new CheckBox[col];
            for (int i=0; i< col; i++)
            {
                RowStyle style = new RowStyle(SizeType.AutoSize);
                tableLayoutPanel1.RowStyles.Add(style);
                matr_lable[i] = new Label();
                matr_check[i] = new CheckBox();
                matr_lable[i].Text = "Название детали №"+(i+1);
                matr_lable[i].Width = 280;
                matr_check[i].Text = "";
                tableLayoutPanel1.Controls.Add(matr_lable[i], 0, i);
                tableLayoutPanel1.Controls.Add(matr_check[i], 1, i);
            }
          // this.tableLayoutPanel1.ColumnStyles[0].Width = 100;
            this.tableLayoutPanel1.ColumnStyles[1].Width = 30;
            tableLayoutPanel1.Refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
