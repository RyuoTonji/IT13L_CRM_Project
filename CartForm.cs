using MyKioski.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyKioski
{
    public partial class CartForm : Form
    {
        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            BindDataToGrid();
        }

        // This method displays your items, prices, quantities, and subtotals
        private void BindDataToGrid()
        {
            dgvCart.Rows.Clear();
            dgvCart.Columns.Clear();

            // Set up the columns
            dgvCart.Columns.Add("ItemName", "Item");
            dgvCart.Columns.Add("Price", "Price");
            dgvCart.Columns.Add("Quantity", "Qty");
            dgvCart.Columns.Add("Subtotal", "Subtotal");


            DataGridViewButtonColumn btnDecrease = new DataGridViewButtonColumn { Name = "Decrease", Text = "-", UseColumnTextForButtonValue = true, Width = 40 };
            DataGridViewButtonColumn btnIncrease = new DataGridViewButtonColumn { Name = "Increase", Text = "+", UseColumnTextForButtonValue = true, Width = 40 };


            dgvCart.Columns.Add(btnDecrease);
            dgvCart.Columns.Add(btnIncrease);
            // Fill the grid with items from the Cart
            foreach (var cartItem in Cart.items)
            {
                dgvCart.Rows.Add(
                    cartItem.Item.Name,
                    $"₱{cartItem.Item.Price:F2}",
                    cartItem.Quantity,
                    $"₱{cartItem.Subtotal:F2}"
                );
                dgvCart.Rows[dgvCart.Rows.Count - 1].Tag = cartItem.Item.Id;
            }

            // Style and formatting
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.Columns["Quantity"].Width = 60;
            dgvCart.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Update the final total price at the bottom
            lblFinalTotal.Text = $"Final Total: ₱{Cart.GetTotal():F2}";
        }

        // This method handles all clicks inside the grid
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore clicks on the header

            int itemId = (int)dgvCart.Rows[e.RowIndex].Tag;

            // This handles the "quantity decrease" when you click '-'
            if (dgvCart.Columns[e.ColumnIndex].Name == "Decrease")
            {
                Cart.DecreaseQuantity(itemId);
            }
            // This handles the "subtotal increase" (by increasing quantity) when you click '+'
            else if (dgvCart.Columns[e.ColumnIndex].Name == "Increase")
            {
                Cart.IncreaseQuantity(itemId);
            }

            // After any change, refresh the entire grid to show the new values
            BindDataToGrid();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            DialogResult result = paymentForm.ShowDialog();

            //if (Cart.GetItemCount() > 0)
            //{
                // Open the PaymentForm as a dialog window
              //  PaymentForm paymentForm = new PaymentForm();
                //DialogResult result = paymentForm.ShowDialog();

                // After the payment form closes, if the payment was successful (OK),
                // then close the cart form as well.
                //if (result == DialogResult.OK)
                //{
                  //  this.Close();
                //}
            //}
            //else
            //{
              //  MessageBox.Show("Your cart is empty.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
    }
}