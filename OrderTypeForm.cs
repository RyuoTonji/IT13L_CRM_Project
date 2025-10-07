using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MyKioskApp.Properties;

namespace MyKioski
{
    public partial class OrderTypeForm : Form
    {
        public OrderTypeForm()
        {
            InitializeComponent();

            // Load button images at runtime from Assets folder
            try
            {

                btnTakeOut.BackgroundImage = Resources.take_out;
                btnTakeOut.BackgroundImageLayout = ImageLayout.Stretch;

                btnDineIn.BackgroundImage = Resources.dineIn;
                btnDineIn.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading images: " + ex.Message);
            }
        }

        private void OrderTypeForm_Load(object sender, EventArgs e)
        {
            // Connect both buttons to the same click event handler
            btnDineIn.Click += new EventHandler(OrderTypeButton_Click);
            btnTakeOut.Click += new EventHandler(OrderTypeButton_Click);
        }

        private void OrderTypeButton_Click(object sender, EventArgs e)
        {
            // Optional: detect which button was clicked
            // Button clickedButton = sender as Button;
            // string orderType = clickedButton.Text;
            // MessageBox.Show("You selected: " + orderType);

            // Show the MenuForm
            MenuForm menuForm = new MenuForm();
            menuForm.Show();

            // Hide this form
            this.Hide();
        }
    }
}
