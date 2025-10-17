using MyKioski.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace MyKioski
{
    public static class OrderService
    {
        private static readonly string connectionString = @"Server=DRACARYS\SQLEXPRESS;Database=MyKioskApp;Integrated Security=true;TrustServerCertificate=true;";

        public static List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    OrderID,
                    date,
                    total_price,
                    status
                FROM Orders
                ORDER BY date DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                OrderId = reader["OrderID"].ToString(),
                                PaymentMethod = "Cash", // Default since column doesn't exist
                                OrderDateTime = Convert.ToDateTime(reader["date"]),
                                TotalAmount = Convert.ToDecimal(reader["total_price"]),
                                OrderStatus = reader["status"].ToString(),
                                Items = new List<CartItem>()
                            };
                            orders.Add(order);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error loading orders: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Database Error");
            }

            return orders;
        }

        public static Order GetOrderWithItems(string orderId)
        {
            Order order = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Get order details using ACTUAL column names
                    string orderQuery = @"
                        SELECT OrderID, date, total_price, status
                        FROM Orders
                        WHERE OrderID = @OrderId";

                    using (SqlCommand cmd = new SqlCommand(orderQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                order = new Order
                                {
                                    OrderId = reader["OrderID"].ToString(),
                                    PaymentMethod = "Cash", // Default
                                    OrderDateTime = Convert.ToDateTime(reader["date"]),
                                    TotalAmount = Convert.ToDecimal(reader["total_price"]),
                                    OrderStatus = reader["status"].ToString(),
                                    Items = new List<CartItem>()
                                };
                            }
                        }
                    }

                    // Get order items if they exist - FIXED to use actual column names
                    if (order != null)
                    {
                        string itemsQuery = @"
                            SELECT 
                                oi.productid,
                                p.productname,
                                p.price,
                                oi.quantity
                            FROM OrderItems oi
                            INNER JOIN products p ON oi.productid = p.ProductID
                            WHERE oi.orderid = @OrderId";

                        using (SqlCommand cmd = new SqlCommand(itemsQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@OrderId", orderId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    CartItem item = new CartItem
                                    {
                                        Item = new MenuItem
                                        {
                                            Id = Convert.ToInt32(reader["productid"]),
                                            Name = reader["productname"].ToString(),
                                            Price = Convert.ToDecimal(reader["price"])
                                        },
                                        Quantity = Convert.ToInt32(reader["quantity"])
                                    };
                                    order.Items.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error loading order details: {ex.Message}", "Database Error");
            }

            return order;
        }

        public static void SaveOrder(Order newOrder)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Insert order using ACTUAL column names
                            string orderQuery = @"
                                INSERT INTO Orders (OrderID, date, total_price, status)
                                VALUES (@OrderId, @OrderDateTime, @TotalAmount, @OrderStatus)";

                            using (SqlCommand cmd = new SqlCommand(orderQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@OrderId", newOrder.OrderId);
                                cmd.Parameters.AddWithValue("@OrderDateTime", newOrder.OrderDateTime);
                                cmd.Parameters.AddWithValue("@TotalAmount", newOrder.TotalAmount);
                                cmd.Parameters.AddWithValue("@OrderStatus", newOrder.OrderStatus);
                                cmd.ExecuteNonQuery();
                            }

                            // Insert order items - FIXED to use actual column names
                            string itemQuery = @"
                                INSERT INTO OrderItems (orderid, productid, quantity, subtotal)
                                VALUES (@OrderId, @ProductId, @Quantity, @Subtotal)";

                            foreach (var item in newOrder.Items)
                            {
                                using (SqlCommand cmd = new SqlCommand(itemQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@OrderId", newOrder.OrderId);
                                    cmd.Parameters.AddWithValue("@ProductId", item.Item.Id);
                                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                                    cmd.Parameters.AddWithValue("@Subtotal", item.Item.Price * item.Quantity);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error saving order: {ex.Message}", "Database Error");
            }
        }

        public static void DeleteOrder(string orderId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Delete order items first (foreign key constraint) - FIXED column name
                            string deleteItemsQuery = "DELETE FROM OrderItems WHERE orderid = @OrderId";
                            using (SqlCommand cmd = new SqlCommand(deleteItemsQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@OrderId", orderId);
                                cmd.ExecuteNonQuery();
                            }

                            // Delete order using ACTUAL column name
                            string deleteOrderQuery = "DELETE FROM Orders WHERE OrderID = @OrderId";
                            using (SqlCommand cmd = new SqlCommand(deleteOrderQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@OrderId", orderId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error deleting order: {ex.Message}", "Database Error");
            }
        }

        // --- Analytics Methods (using ACTUAL column names) ---
        public static decimal GetTotalSales()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ISNULL(SUM(total_price), 0) FROM Orders";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        return Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public static decimal GetAverageDailySales()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT AVG(DailySales) 
                        FROM (
                            SELECT CAST(date AS DATE) as OrderDate, SUM(total_price) as DailySales
                            FROM Orders
                            GROUP BY CAST(date AS DATE)
                        ) as DailySalesData";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public static decimal GetAverageWeeklySales()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT AVG(WeeklySales) 
                        FROM (
                            SELECT DATEPART(WEEK, date) as WeekNum, SUM(total_price) as WeeklySales
                            FROM Orders
                            GROUP BY DATEPART(WEEK, date), DATEPART(YEAR, date)
                        ) as WeeklySalesData";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public static decimal GetAverageMonthlySales()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT AVG(MonthlySales) 
                        FROM (
                            SELECT YEAR(date) as OrderYear, MONTH(date) as OrderMonth, SUM(total_price) as MonthlySales
                            FROM Orders
                            GROUP BY YEAR(date), MONTH(date)
                        ) as MonthlySalesData";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public static Dictionary<DateTime, decimal> GetDailySalesForLastDays(int days)
        {
            Dictionary<DateTime, decimal> dailySales = new Dictionary<DateTime, decimal>();

            // Initialize with zeros for all days
            for (int i = days - 1; i >= 0; i--)
            {
                dailySales[DateTime.Today.AddDays(-i)] = 0;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT CAST(date AS DATE) as OrderDate, SUM(total_price) as TotalSales
                        FROM Orders
                        WHERE date >= @StartDate
                        GROUP BY CAST(date AS DATE)
                        ORDER BY CAST(date AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", DateTime.Today.AddDays(-days + 1));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime date = Convert.ToDateTime(reader["OrderDate"]);
                                decimal sales = Convert.ToDecimal(reader["TotalSales"]);
                                if (dailySales.ContainsKey(date))
                                {
                                    dailySales[date] = sales;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error loading daily sales: {ex.Message}", "Database Error");
            }

            return dailySales;
        }

        public static Dictionary<string, int> GetSalesByItem()
        {
            Dictionary<string, int> salesByItem = new Dictionary<string, int>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT p.productname, SUM(oi.quantity) as TotalQuantity
                        FROM OrderItems oi
                        INNER JOIN products p ON oi.productid = p.ProductID
                        GROUP BY p.productname
                        ORDER BY TotalQuantity DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["productname"].ToString();
                            int quantity = Convert.ToInt32(reader["TotalQuantity"]);
                            salesByItem[itemName] = quantity;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error loading item sales: {ex.Message}", "Database Error");
            }

            return salesByItem;
        }
    }
}