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
    public partial class UserControl_spec : UserControl
    {
        public UserControl_spec()
        {
            InitializeComponent();
            label1.AutoSize = false;
            label1.Paint += Label1_Paint;
            label2.AutoSize = false;
            label2.Paint += Label2_Paint;
        }

        private void UserControl_spec_Load(object sender, EventArgs e)
        {

        }
        private void Label1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.WhiteSmoke);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(label1.Text, label1.Font);
            label1.Width = (int)textSize.Height + 2;
            label1.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-label1.Height / 2, label1.Width / 2);
            e.Graphics.DrawString(label1.Text, label1.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        private void Label2_Paint(object sender, PaintEventArgs q)
        {
            q.Graphics.Clear(Color.WhiteSmoke);
            q.Graphics.RotateTransform(-90);
            SizeF textSize = q.Graphics.MeasureString(label2.Text, label2.Font);
            label2.Width = (int)textSize.Height + 2;
            label2.Height = (int)textSize.Width + 2;
            q.Graphics.TranslateTransform(-label2.Height / 2, label2.Width / 2);
            q.Graphics.DrawString(label2.Text, label2.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
