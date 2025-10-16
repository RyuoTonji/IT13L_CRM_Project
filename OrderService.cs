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
        // TODO: Update this connection string with your SQL Server details
        private static readonly string connectionString = @"Server=DRACARYS\SQLEXPRESS;Database=MyKioskApp;Integrated Security=true;";

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
                                PaymentMethod = "Cash", // placeholder since column doesn’t exist
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
                System.Windows.Forms.MessageBox.Show($"Error loading orders: {ex.Message}", "Database Error");
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

                    // Get order details
                    string orderQuery = @"
                        SELECT OrderId, PaymentMethod, OrderDateTime, TotalAmount, OrderStatus
                        FROM Orders
                        WHERE OrderId = @OrderId";

                    using (SqlCommand cmd = new SqlCommand(orderQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                order = new Order
                                {
                                    OrderId = reader["OrderId"].ToString(),
                                    PaymentMethod = reader["PaymentMethod"].ToString(),
                                    OrderDateTime = Convert.ToDateTime(reader["OrderDateTime"]),
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                                    OrderStatus = reader["OrderStatus"].ToString(),
                                    Items = new List<CartItem>()
                                };
                            }
                        }
                    }

                    // Get order items
                    if (order != null)
                    {
                        string itemsQuery = @"
                            SELECT 
                                oi.ItemId,
                                oi.ItemName,
                                oi.ItemPrice,
                                oi.Quantity
                            FROM OrderItems oi
                            WHERE oi.OrderId = @OrderId";

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
                                            Id = Convert.ToInt32(reader["ItemId"]),
                                            Name = reader["ItemName"].ToString(),
                                            Price = Convert.ToDecimal(reader["ItemPrice"])
                                        },
                                        Quantity = Convert.ToInt32(reader["Quantity"])
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
                            // Insert order
                            string orderQuery = @"
                                INSERT INTO Orders (OrderId, PaymentMethod, OrderDateTime, TotalAmount, OrderStatus)
                                VALUES (@OrderId, @PaymentMethod, @OrderDateTime, @TotalAmount, @OrderStatus)";

                            using (SqlCommand cmd = new SqlCommand(orderQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@OrderId", newOrder.OrderId);
                                cmd.Parameters.AddWithValue("@PaymentMethod", newOrder.PaymentMethod);
                                cmd.Parameters.AddWithValue("@OrderDateTime", newOrder.OrderDateTime);
                                cmd.Parameters.AddWithValue("@TotalAmount", newOrder.TotalAmount);
                                cmd.Parameters.AddWithValue("@OrderStatus", newOrder.OrderStatus);
                                cmd.ExecuteNonQuery();
                            }

                            // Insert order items
                            string itemQuery = @"
                                INSERT INTO OrderItems (OrderId, ItemId, ItemName, ItemPrice, Quantity)
                                VALUES (@OrderId, @ItemId, @ItemName, @ItemPrice, @Quantity)";

                            foreach (var item in newOrder.Items)
                            {
                                using (SqlCommand cmd = new SqlCommand(itemQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@OrderId", newOrder.OrderId);
                                    cmd.Parameters.AddWithValue("@ItemId", item.Item.Id);
                                    cmd.Parameters.AddWithValue("@ItemName", item.Item.Name);
                                    cmd.Parameters.AddWithValue("@ItemPrice", item.Item.Price);
                                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
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
                            // Delete order items first (foreign key constraint)
                            string deleteItemsQuery = "DELETE FROM OrderItems WHERE OrderId = @OrderId";
                            using (SqlCommand cmd = new SqlCommand(deleteItemsQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@OrderId", orderId);
                                cmd.ExecuteNonQuery();
                            }

                            // Delete order
                            string deleteOrderQuery = "DELETE FROM Orders WHERE OrderId = @OrderId";
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

        // --- Analytics Methods ---
        public static decimal GetTotalSales()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders";
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
                            SELECT CAST(OrderDateTime AS DATE) as OrderDate, SUM(TotalAmount) as DailySales
                            FROM Orders
                            GROUP BY CAST(OrderDateTime AS DATE)
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
                            SELECT DATEPART(WEEK, OrderDateTime) as WeekNum, SUM(TotalAmount) as WeeklySales
                            FROM Orders
                            GROUP BY DATEPART(WEEK, OrderDateTime), DATEPART(YEAR, OrderDateTime)
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
                            SELECT YEAR(OrderDateTime) as OrderYear, MONTH(OrderDateTime) as OrderMonth, SUM(TotalAmount) as MonthlySales
                            FROM Orders
                            GROUP BY YEAR(OrderDateTime), MONTH(OrderDateTime)
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

            // Initialize with zeros
            for (int i = 0; i < days; i++)
            {
                dailySales[DateTime.Today.AddDays(-i)] = 0;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT CAST(OrderDateTime AS DATE) as OrderDate, SUM(TotalAmount) as TotalSales
                        FROM Orders
                        WHERE OrderDateTime >= @StartDate
                        GROUP BY CAST(OrderDateTime AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", DateTime.Today.AddDays(-days + 1));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime date = Convert.ToDateTime(reader["OrderDate"]);
                                decimal sales = Convert.ToDecimal(reader["TotalSales"]);
                                dailySales[date] = sales;
                            }
                        }
                    }
                }
            }
            catch
            {
                // Return initialized dictionary with zeros
            }

            return dailySales.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
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
                        SELECT ItemName, SUM(Quantity) as TotalQuantity
                        FROM OrderItems
                        GROUP BY ItemName
                        ORDER BY TotalQuantity DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["ItemName"].ToString();
                            int quantity = Convert.ToInt32(reader["TotalQuantity"]);
                            salesByItem[itemName] = quantity;
                        }
                    }
                }
            }
            catch
            {
                // Return empty dictionary
            }

            return salesByItem;
        }
    }
}