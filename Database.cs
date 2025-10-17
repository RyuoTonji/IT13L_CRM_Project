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

        public static void InsertFeedback(string email, string concern, string comments)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                // Step 1: Get UserID based on Email
                string getUserQuery = "SELECT UserID FROM Users WHERE Email = @Email";
                int userId;

                using (SqlCommand cmd = new SqlCommand(getUserQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                        throw new Exception("No user found with that email.");

                    userId = Convert.ToInt32(result);
                }

                // Step 2: Insert feedback
                string insertQuery = @"
            INSERT INTO Feedback (UserID, Concern, Comments, SubmittedAt, Status)
            VALUES (@UserID, @Concern, @Comments, GETDATE(), 'Pending');
        ";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Concern", concern);
                    cmd.Parameters.AddWithValue("@Comments", comments);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetFeedbackList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                u.Email,
                f.Concern AS Type,
                CONVERT(varchar(10), f.SubmittedAt, 101) AS Date,
                CONVERT(varchar(8), f.SubmittedAt, 108) AS Time,
                f.Status
            FROM Feedback f
            INNER JOIN Users u ON f.UserID = u.UserID
            ORDER BY f.SubmittedAt DESC;
        ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }


    }
}
