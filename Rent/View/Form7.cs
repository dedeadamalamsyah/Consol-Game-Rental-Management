using Guna.UI2.WinForms;
using MySqlConnector;
using Rent.Controller;
using Rent.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Rent.View
{
    public partial class Form7 : Form
    {
        private ReturnController retc;
        private RentController renc;
        private Connection conn;

        public Form7()
        {
            retc = new ReturnController();
            renc = new RentController();
            conn = new Connection();
            InitializeComponent();

            DateTime tomorrow = DateTime.Today.AddDays(1);
            guna2DateTimePicker1.MinDate = tomorrow;
        }

        private void refresh()
        {
            Controls.Clear();
            InitializeComponent();

            dataGridView1.DataSource = renc.readRent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.DataSource = retc.readReturn();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            guna2DateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;
            DateTime d1 = guna2DateTimePicker1.Value.Date;
            DateTime d2 = DateTime.Now;
            TimeSpan ts = d2 - d1;
            int day = (int)ts.TotalDays;
            if(day<=0)
            {
                textBox4.Text = "-";
                textBox5.Enabled = false;
                textBox5.Text = "-";
            }
            else
            {
                textBox4.Text = day.ToString();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            retc.addReturn(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), textBox3.Text, guna2DateTimePicker1.Value, textBox4.Text, textBox5.Text);
            refresh();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string search = "SELECT * FROM rents WHERE CONCAT (idrent, idconsole, custname, rentdate, returndate, cost) like '%" + textBox7.Text + "%'";
            MySqlDataAdapter da = new MySqlDataAdapter(search, conn.GetConn());
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string search = "SELECT * FROM returns WHERE CONCAT (idrent, idconsole, custname, returndate, delay, fine) like '%" + textBox4.Text + "%'";
            MySqlDataAdapter da = new MySqlDataAdapter(search, conn.GetConn());
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
