using System.Data.SqlClient;

namespace Communityclinic
{
    public static class DatabaseHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(
                "Data Source=desktop-e4f55fe;Initial Catalog=CommunityClinicLLOMDB;Integrated Security=True"
            );
        }
    }
}