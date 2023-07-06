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
    public partial class Form8 : Form
    {
        private ReturnController retc;
        private RentController renc;
        private HistoryController hc;
        private Connection conn;

        public Form8()
        {
            conn = new Connection();
            hc = new HistoryController();
            retc = new ReturnController();
            renc = new RentController();
            InitializeComponent();
        }

        private void refresh()
        {
            dataGridView1.DataSource = hc.readHistory();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void reload()
        {
            Controls.Clear();
            InitializeComponent();
            refresh();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap btm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(btm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            e.Graphics.DrawImage(btm, 135, 100);
            e.Graphics.DrawString(label14.Text, new Font("Consolas", 23, FontStyle.Bold), Brushes.Black, new Point(200, 50));
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int selectedValue = (int)dataGridView1.SelectedRows[0].Cells["idtransaction"].Value;
            hc.deleteHistory(selectedValue);
            refresh();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string search = "SELECT * FROM histories WHERE CONCAT (idtransaction, idconsole, custname, rentdate, returndate, cost, delay, fine) like '%" + textBox7.Text + "%'";
            MySqlDataAdapter da = new MySqlDataAdapter(search, conn.GetConn());
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
