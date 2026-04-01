using System.Data.SqlClient;

public static class DatabaseHelper
{
    private static string connectionString =
        @"Data Source=TEEN-HUB-LAP-03;Initial Catalog=CommunityCareDB;Integrated Security=True";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}
