using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class 辅助弟弟学习 : Form
    {
        private int minutes = 0;
        public 辅助弟弟学习()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                int CS_NOCLOSE = 0x200;
                CreateParams parameters = base.CreateParams;
                parameters.ClassStyle |= CS_NOCLOSE;
                return parameters;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fm1 = (Form1)this.Owner;
            int h = (int)this.numericUpDown1.Value;
            int m = (int)this.numericUpDown2.Value;
            this.minutes = h * 60 + m;
            fm1.minutes = h * 60 + m;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Never Give Up!");
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.minutes <= 0)
            {
                MessageBox.Show("你玩你妈呢¿","弟弟",MessageBoxButtons.OK,MessageBoxIcon.Question);
                e.Cancel = true;
            }
        }
    }
}
