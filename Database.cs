using System.Data;
using Microsoft.Data.SqlClient;

namespace MyKioski
{
    public static class Database
    {
        private static readonly string connectionString =
            "Data Source=DRACARYS\\SQLEXPRESS;Initial Catalog=MykioskApp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable GetProducts()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ProductId, ProductName, Category, Price, Description FROM Products", conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
    }
}
