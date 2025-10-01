using MyKioski.Models;
using System;
using System.Windows.Forms;

namespace MyKioski
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // Get the final total from the Cart and display it
            lblAmountDue.Text = $"Amount Due: ₱{Cart.GetTotal():F2}";
        }

        private void btnPayCash_Click(object sender, EventArgs e)
        {
            // Show a final message
            MessageBox.Show($"Thank you for your order! Please pay ₱{Cart.GetTotal():F2} at the counter.", "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the cart for the next customer
            Cart.ClearCart();

            // Set the DialogResult to OK, which tells the CartForm that payment was successful
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnPayGCash_Click(object sender, EventArgs e)
        {
            // In a real app, this would show a QR code. For now, we'll just show a message.
            MessageBox.Show($"Thank you for your order! Please scan the GCash QR code at the counter to pay ₱{Cart.GetTotal():F2}.", "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the cart for the next customer
            Cart.ClearCart();

            // Set the DialogResult to OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}