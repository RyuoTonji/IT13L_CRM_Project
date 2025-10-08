using MyKioski.Models;
using QRCoder;
using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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

        private async void btnPayGCash_Click(object sender, EventArgs e)
        {
            try
            {
                decimal totalAmount = Cart.GetTotal();
                long amountInCentavos = (long)(totalAmount * 100); // PayMongo uses centavos

                string secretKey = "sk_test_UgfaveVmmD1bAwJ2N8VTVjpP"; // Replace with your test secret key
                string authHeader = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(secretKey));

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Basic " + authHeader);

                    var requestData = new
                    {
                        data = new
                        {
                            attributes = new
                            {
                                amount = amountInCentavos,
                                currency = "PHP",
                                type = "gcash",
                                redirect = new
                                {
                                    success = "https://yourapp.com/success",
                                    failed = "https://yourapp.com/failed"
                                }
                            }
                        }
                    };

                    string jsonString = System.Text.Json.JsonSerializer.Serialize(requestData);
                    var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://api.paymongo.com/v1/sources", content);
                    string responseString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error creating payment source:\n" + responseString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var jsonDoc = System.Text.Json.JsonDocument.Parse(responseString);
                    string checkoutUrl = jsonDoc
                        .RootElement
                        .GetProperty("data")
                        .GetProperty("attributes")
                        .GetProperty("redirect")
                        .GetProperty("checkout_url")
                        .GetString();

                    // Generate QR Code
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(checkoutUrl, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);

                    // Show in PictureBox (make sure you have a PictureBox named "pictureBoxQR" on your form)
                    pictureBoxQR.Image = qrCode.GetGraphic(5);

                    // Clear the cart
                    Cart.ClearCart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}