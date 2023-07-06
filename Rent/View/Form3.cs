using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent.View
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
