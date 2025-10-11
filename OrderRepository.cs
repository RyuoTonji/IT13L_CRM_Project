using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MyKioski.Models
{
    public class OrderRepository
    {
        private readonly string connectionString =
            @"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=MyKioskApp;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        // Constants for user types
        private const int GUEST_USER_ID = 10; // Using existing user
        private const int MEMBER_USER_ID = 10; // Your existing member user

        // Insert a new order and return the generated OrderID
        // Pass userId = 0 or negative for guest orders
        // Pass userId > 0 for member orders
        public int InsertOrder(int userId, string status, double totalPrice)
        {
            int newOrderId = 0;

            // DEBUG: Log what userId was passed in
            System.Diagnostics.Debug.WriteLine($"InsertOrder called with userId: {userId}");

            // Determine if guest or member
            if (userId <= 0)
            {
                // Guest order (non-member)
                userId = GUEST_USER_ID;
                System.Diagnostics.Debug.WriteLine($"Guest order - using UserID: {userId}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Member order - using UserID: {userId}");
            }
            // else: use the provided userId for member orders

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // DEBUG: Check if user exists
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserID = @userid";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@userid", userId);
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount == 0)
                    {
                        throw new Exception($"ERROR: UserID {userId} does not exist in Users table! Check your database.");
                    }
                }

                string query = @"INSERT INTO Orders (date, userid, status, total_price)
                         OUTPUT INSERTED.OrderID
                         VALUES (@date, @userid, @status, @total_price)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@total_price", totalPrice);
                    newOrderId = (int)cmd.ExecuteScalar();
                }
            }
            return newOrderId;
        }

        // Overload method for guest orders (simpler to call)
        public int InsertGuestOrder(string status, double totalPrice)
        {
            return InsertOrder(0, status, totalPrice);
        }

        // Overload method for member orders (more explicit)
        public int InsertMemberOrder(int memberId, string status, double totalPrice)
        {
            if (memberId <= 0)
            {
                throw new ArgumentException("Member ID must be greater than 0");
            }
            return InsertOrder(memberId, status, totalPrice);
        }

        // Insert an order item (OrderItems table)
        public void InsertOrderItem(int orderId, int productId, int quantity, double subtotal)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO OrderItems (orderid, productid, quantity, subtotal)
                                 VALUES (@orderid, @productid, @quantity, @subtotal)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@orderid", orderId);
                    cmd.Parameters.AddWithValue("@productid", productId);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@subtotal", subtotal);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Load all products from the Products table
        public DataTable LoadProducts()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT ProductID, productname, category, price, description FROM Products";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        // Get product price by ID
        public decimal GetProductPrice(int productId)
        {
            decimal price = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT price FROM Products WHERE ProductID = @productId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        price = Convert.ToDecimal(result);
                }
            }

            return price;
        }

        // Verify if a user is a member
        public bool IsMember(int userId)
        {
            if (userId <= 0) return false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE UserID = @userId AND UserID != @guestId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@guestId", GUEST_USER_ID);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Get user info by ID
        public DataRow GetUserInfo(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserID, username, firstname, lastname, email FROM Users WHERE UserID = @userId";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@userId", userId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }


    }
}