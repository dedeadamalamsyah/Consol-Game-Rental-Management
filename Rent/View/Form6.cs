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
    public partial class Form6 : Form
    {
        private RentController renc;
        private Connection conn;

        public Form6()
        {
            renc = new RentController();
            conn = new Connection();
            InitializeComponent();
            guna2DateTimePicker1.MinDate = DateTime.Today;
            DateTime tomorrow = DateTime.Today.AddDays(1);
            guna2DateTimePicker2.MinDate = tomorrow;
        }

        private void refresh()
        {
            Controls.Clear();
            InitializeComponent();
            dataGridView1.DataSource = renc.readRent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            idconsole();
            idcustomer();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            refresh();
            idconsole();
            idcustomer();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            guna2DateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
            guna2DateTimePicker2.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            renc.addRent(Convert.ToInt32(textBox1.Text), Convert.ToInt32(comboBox1.Text), textBox2.Text, guna2DateTimePicker1.Value, guna2DateTimePicker2.Value, Convert.ToInt32(textBox3.Text));
            refresh();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            renc.updateRent(Convert.ToInt32(textBox1.Text), Convert.ToInt32(comboBox1.Text), textBox2.Text, guna2DateTimePicker1.Value, guna2DateTimePicker2.Value, Convert.ToInt32(textBox3.Text));
            refresh();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int selectedValue = (int)dataGridView1.SelectedRows[0].Cells["idrent"].Value;
            renc.deleteCustomer(selectedValue);
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

        private void idconsole()
        {
            DataTable data = new DataTable();
            string idconsole = "SELECT idconsole FROM consoles WHERE available = 'Yes'";
            conn.cmd = new MySqlCommand(idconsole, conn.GetConn());
            conn.dr = conn.cmd.ExecuteReader();
            data.Columns.Add("idconsole", typeof(Int32));
            data.Load(conn.dr);
            comboBox1.ValueMember = "idconsole";
            comboBox1.DataSource = data;
        }

        private void idcustomer()
        {
            DataTable data = new DataTable();
            string idcustomer = "SELECT idcustomer FROM customers";
            conn.cmd = new MySqlCommand(idcustomer, conn.GetConn());
            conn.dr = conn.cmd.ExecuteReader();
            data.Columns.Add("idcustomer", typeof(Int32));
            data.Load(conn.dr);
            guna2ComboBox1.ValueMember = "idcustomer";
            guna2ComboBox1.DataSource = data;
        }

        private void custName()
        {
            string custname = "SELECT * FROM customers WHERE idcustomer = " + guna2ComboBox1.SelectedValue;
            conn.cmd = new MySqlCommand(custname, conn.GetConn());
            DataTable data = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(conn.cmd);
            da.Fill(data);
            foreach(DataRow dr in data.Rows)
            {
                textBox2.Text = dr["name"].ToString();
            }
        }

        private void guna2ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            custName();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string search = "SELECT * FROM rents WHERE CONCAT (idrent, idconsole, custname, rentdate, returndate, cost) like '%" + textBox4.Text + "%'";
            MySqlDataAdapter da = new MySqlDataAdapter(search, conn.GetConn());
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
