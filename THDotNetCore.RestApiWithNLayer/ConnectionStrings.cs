using System.Data.SqlClient;

namespace THDotNetCore.RestApiWithNLayer
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "THDotNetCore",
            UserID = "sa",
            Password = "r00tp@ss",
            TrustServerCertificate = true
        };
    }
}
