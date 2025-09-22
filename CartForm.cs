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

        private void BindDataToGrid()
        {
            dgvCart.Rows.Clear();
            dgvCart.Columns.Clear();

            dgvCart.Columns.Add("ItemName", "Item");
            dgvCart.Columns.Add("Price", "Price");
            dgvCart.Columns.Add("Quantity", "Qty");
            dgvCart.Columns.Add("Subtotal", "Subtotal");

            DataGridViewButtonColumn btnIncrease = new DataGridViewButtonColumn { Name = "Increase", Text = "+", UseColumnTextForButtonValue = true, Width = 40 };
            DataGridViewButtonColumn btnDecrease = new DataGridViewButtonColumn { Name = "Decrease", Text = "-", UseColumnTextForButtonValue = true, Width = 40 };

            dgvCart.Columns.Add(btnDecrease);
            dgvCart.Columns.Add(btnIncrease);

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

            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.Columns["Quantity"].Width = 60;
            dgvCart.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            lblFinalTotal.Text = $"Final Total: ₱{Cart.GetTotal():F2}";
        }

        // This method will now be correctly connected and will run on clicks.
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int itemId = (int)dgvCart.Rows[e.RowIndex].Tag;

            if (dgvCart.Columns[e.ColumnIndex].Name == "Increase")
            {
                Cart.IncreaseQuantity(itemId);
            }
            else if (dgvCart.Columns[e.ColumnIndex].Name == "Decrease")
            {
                Cart.DecreaseQuantity(itemId);
            }

            // This is the important line that refreshes the display after a change.
            BindDataToGrid();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (Cart.GetItemCount() > 0)
            {
                MessageBox.Show($"Thank you for your order! Your total is ₱{Cart.GetTotal():F2}. Please pay at the counter.", "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cart.ClearCart();
                this.Close();
            }
            else
            {
                MessageBox.Show("Your cart is empty.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}