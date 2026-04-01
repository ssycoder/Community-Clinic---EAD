using System;
using System.Data.SqlClient;

namespace Communityclinic
{
    public static class DatabaseHelper
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(
                    "Data Source=23.95.235.16;Initial Catalog=CommunityClinicLLOMDB;User ID=vtdi_student;Password=P@ssword1;TrustServerCertificate=True"
                );

                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed: " + ex.Message);
            }
        }
    }
}