using System;
using System.Data;
using System.Drawing;
using System.IO;
using Microsoft.Data.SqlClient;

namespace MyKioski.Models
{
    public class ProductImageManager
    {
        private readonly string connectionString =
            @"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=MyKioskApp;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        // Insert a product WITH an image
        public int InsertProductWithImage(string productName, string category, decimal price,
            string description, string imagePath)
        {
            int newProductId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO Products (productname, category, price, description, productimage)
                                OUTPUT INSERTED.ProductID
                                VALUES (@productname, @category, @price, @description, @productimage)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productname", productName);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@description", description ?? (object)DBNull.Value);

                    // Convert image file to byte array
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        byte[] imageBytes = File.ReadAllBytes(imagePath);
                        cmd.Parameters.AddWithValue("@productimage", imageBytes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@productimage", DBNull.Value);
                    }

                    newProductId = (int)cmd.ExecuteScalar();
                }
            }

            return newProductId;
        }

        // Load all products WITH images
        public DataTable LoadProductsWithImages()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT ProductID, productname, category, price, description, productimage FROM Products";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        // Get a single product image
        public Image GetProductImage(int productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT productimage FROM Products WHERE ProductID = @productId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])result;
                        return ByteArrayToImage(imageBytes);
                    }
                }
            }

            return null;
        }

        // Helper: Convert byte array to Image
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        // Update product details
        public void UpdateProduct(int productId, string productName, string category,
            decimal price, string description)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"UPDATE Products 
                                SET productname = @productname, 
                                    category = @category, 
                                    price = @price, 
                                    description = @description 
                                WHERE ProductID = @productId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@productname", productName);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@description", description ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete a product
        public void DeleteProduct(int productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Products WHERE ProductID = @productId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}