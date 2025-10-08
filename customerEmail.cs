using MyKioski.Models;

namespace MyKioski
{
    public partial class customerEmail : Form
    {
        public customerEmail()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your feedback has been sent! Thank you.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string email = emailTextBox.Text;
          //  string concern = concernTextBox.Text;
            MessageBox.Show("Your feedback has been saved as a draft.", "Draft Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
