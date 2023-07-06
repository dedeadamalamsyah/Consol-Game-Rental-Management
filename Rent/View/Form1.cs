namespace Rent.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int loading = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            loading++;
            guna2ProgressBar1.Value = loading;
            label3.Text = loading + "%";
            if(guna2ProgressBar1.Value == 100)
            {
                guna2ProgressBar1.Value = 0;
                timer1.Stop();
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}