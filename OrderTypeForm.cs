using System;
using System.Windows.Forms;

namespace MyKioski
{
    public partial class OrderTypeForm : Form
    {
        public OrderTypeForm()
        {
            InitializeComponent();
        }

        private void OrderTypeForm_Load(object sender, EventArgs e)
        {
            // Connect all three buttons to the same click event handler
            btnDineIn.Click += new EventHandler(OrderTypeButton_Click);
            btnTakeOut.Click += new EventHandler(OrderTypeButton_Click); 
        }

        // This single method runs when ANY of the three buttons are clicked
        private void OrderTypeButton_Click(object sender, EventArgs e)
        {
            // Optional: You can find out which button was clicked if you need to save the order type
            // Button clickedButton = sender as Button;
            // string orderType = clickedButton.Text; 
            // MessageBox.Show("You selected: " + orderType);

            // Create and show the MenuForm
            MenuForm menuForm = new MenuForm();
            menuForm.Show();

            // Hide this form
            this.Hide();
        }
    }
}