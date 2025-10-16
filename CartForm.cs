using MyKioskApp;
using MyKioski.Models;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            if (Cart.GetItemCount() > 0)
            {
                this.Hide(); // 👈 Hide only the Cart form

                // Find your Menu form (or whatever form should stay open)
                Form menuForm = Application.OpenForms["MenuForm"]; // change name if your form is called differently

                using (PaymentForm paymentForm = new PaymentForm())
                {
                    paymentForm.StartPosition = FormStartPosition.CenterParent;

                    // 👇 Show dialog with menuForm as owner instead of 'this'
                    DialogResult result = menuForm != null
                        ? paymentForm.ShowDialog(menuForm)
                        : paymentForm.ShowDialog();

                    if (result == DialogResult.Cancel)
                    {
                        // User canceled payment, show cart again
                        this.Show();
                        return;
                    }
                    else if (result == DialogResult.OK)
                    {
                        try
                        {
                            OrderRepository repo = new OrderRepository();
                            int userId = 0;
                            string status = "Completed";
                            double totalPrice = CalculateCartTotal();

                            int orderId = repo.InsertOrder(userId, status, totalPrice);

                            foreach (DataGridViewRow row in dgvCart.Rows)
                            {
                                if (row.Tag != null)
                                {
                                    int productId = Convert.ToInt32(row.Tag);
                                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                                    string subtotalText = row.Cells["Subtotal"].Value.ToString()
                                        .Replace("₱", "")
                                        .Replace(",", "")
                                        .Trim();

                                    if (!double.TryParse(subtotalText, out double subtotal))
                                        throw new Exception($"Failed to parse subtotal: '{subtotalText}'");

                                    decimal productPrice = repo.GetProductPrice(productId);
                                    if (productPrice == 0)
                                        throw new Exception($"Product ID {productId} does not exist in the database!");

                                    repo.InsertOrderItem(orderId, productId, quantity, subtotal);
                                }
                            }

                            MessageBox.Show("Order successfully saved to the database!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close(); // ✅ Close Cart after success
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error saving order: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Show(); // show cart again if something went wrong
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Your cart is empty.", "Empty Cart",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        // Helper method to compute total
        private double CalculateCartTotal()
        {
            double total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    string subtotalText = row.Cells["Subtotal"].Value.ToString()
                        .Replace("₱", "")
                        .Replace(",", "")
                        .Trim();

                    if (double.TryParse(subtotalText, NumberStyles.Any, CultureInfo.InvariantCulture, out double subtotal))
                    {
                        total += subtotal;
                    }
                }
            }
            return total;
        }

        private void LoadProductsFromDatabase()
        {
            try
            {
                DataTable products = Database.GetProducts();

                // Clear the current Cart items (optional)
                Cart.items.Clear();

                foreach (DataRow row in products.Rows)
                {
                    var menuItem = new MenuItem
                    {
                        Id = Convert.ToInt32(row["ProductID"]),
                        Name = row["ProductName"].ToString(),
                        Price = Convert.ToDecimal(row["Price"])
                    };

                    // Add product to cart or product list
                    Cart.AddItemWithQuantity(menuItem, 1); // add 1 unit of each for now
                }

                // Refresh DataGridView
                BindDataToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load products: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}