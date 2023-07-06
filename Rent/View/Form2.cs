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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (admin.Text == "retrogaming101222" && password.Text == "daa23052000")
            {

                Hide();
                Form3 f3 = new Form3();
                f3.Show();
            }
            else
            {
                MessageBox.Show("Wrong admin or password");
                admin.Text = "";
                password.Text = "";
            }
        }

        private void invisible_Click(object sender, EventArgs e)
        {
            invisible.Visible = false;
            visible.Visible = true;
            password.UseSystemPasswordChar = false;
        }

        private void visible_Click(object sender, EventArgs e)
        {
            visible.Visible = false;
            invisible.Visible = true;
            password.UseSystemPasswordChar = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            admin.Text = "";
            password.Text = "";
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
