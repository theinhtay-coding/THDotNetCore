using System.Data.SqlClient;

namespace THDotNetCore.NLayer.DataAccess
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
