using MyKioski.Models;
using System;
using System.Windows.Forms;

namespace MyKioski
{
    public partial class QuantityForm : Form
    {
        private MenuItem currentItem;
        private int quantity = 1;

        // The form now needs a MenuItem to be created
        public QuantityForm(MenuItem item)
        {
            InitializeComponent();
            currentItem = item;
        }

        // This public property will let the MenuForm read the final quantity
        public int SelectedQuantity { get; private set; }

        private void QuantityForm_Load(object sender, EventArgs e)
        {
            // Set the labels based on the item that was passed in
            lblItemName.Text = currentItem.Name;
            lblItemPrice.Text = $"Price: ₱{currentItem.Price:F2}";
            UpdateQuantityLabel();
        }

        private void UpdateQuantityLabel()
        {
            lblQuantity.Text = quantity.ToString();
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            // Don't let quantity go below 1
            if (quantity > 1)
            {
                quantity--;
                UpdateQuantityLabel();
            }
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            quantity++;
            UpdateQuantityLabel();
        }

        private void btnAddItemToCart_Click(object sender, EventArgs e)
        {
            // Store the final quantity in our public property
            this.SelectedQuantity = quantity;
            // Set the dialog result to OK so the MenuForm knows we clicked "Add"
            this.DialogResult = DialogResult.OK;
            // Close the pop-up
            this.Close();
        }
    }
}