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
    public partial class Form5 : Form
    {
        private CustomerController cuc;
        private Validation valid;
        private Connection conn;

        public Form5()
        {
            cuc = new CustomerController();
            valid = new Validation();
            conn = new Connection();
            InitializeComponent();
        }

        private void refresh()
        {
            Controls.Clear();
            InitializeComponent();
            dataGridView1.DataSource = cuc.readCustomer();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {            
            if(Convert.ToInt32(textBox3.Text) < 13 || Convert.ToInt32(textBox3.Text) > 40)
            {
                MessageBox.Show("Must be 13 - 40 years old");
            }
            else
            {
                cuc.addCustomer(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text), textBox4.Text, textBox5.Text);
            }
            refresh();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox3.Text) < 13 || Convert.ToInt32(textBox3.Text) > 40)
            {
                MessageBox.Show("Must be 13 - 40 years old");
            }
            else
            {
                cuc.updateCustomer(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text), textBox4.Text, textBox5.Text);
            }
            refresh();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int selectedValue = (int)dataGridView1.SelectedRows[0].Cells["idcustomer"].Value;
            cuc.deleteCustomer(selectedValue);
            refresh();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string search = "SELECT * FROM customers WHERE CONCAT (idcustomer, name, age, address, phone) like '%" + textBox6.Text + "%'";
            MySqlDataAdapter da = new MySqlDataAdapter(search, conn.GetConn());
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
    }
}
