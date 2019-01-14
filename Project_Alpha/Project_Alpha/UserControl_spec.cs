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
        public string get_pres_name()
        {
            return this.textBox2.Text;
        }
        public string get_pres_s_name()
        {
            return this.textBox4.Text;
        }
        public string get_name()
        {
            return this.textBox1.Text;
        }
        public bool[] get_spec()
        {
            mass_spec[0] = checkBox1.Checked;
            mass_spec[1] = checkBox2.Checked;
            mass_spec[2] = checkBox3.Checked;
            mass_spec[3] = checkBox4.Checked;
            mass_spec[4] = checkBox5.Checked;
            mass_spec[5] = checkBox6.Checked;
            return mass_spec;
        }
        UserControl_bucklers buckler = new UserControl_bucklers();
        UserControl_smallTonn smallTonn = new UserControl_smallTonn();
        Button now_but_act;
        int id_facroty = 0;
        bool create;
        bool[] mass_spec=new bool[6];
        public UserControl_spec(int id_fac,bool create_no)
        {
            InitializeComponent();
            create = create_no;
            id_facroty = id_fac;
            label1.AutoSize = false;
            label1.Paint += Label1_Paint;
            label2.AutoSize = false;
            label2.Paint += Label2_Paint;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            now_but_act = this.button3;
            this.panel1.Controls.Add(buckler);
            now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_active;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_unactive;
            now_but_act = this.button3;
            this.now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_active;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(buckler); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_unactive;
            now_but_act = this.button1;
            this.now_but_act.BackgroundImage = global::Project_Alpha.Properties.Resources.button_active;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(smallTonn); 
        }
    }
}
