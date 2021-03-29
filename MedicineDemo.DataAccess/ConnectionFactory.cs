using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MedicineDemo.DataAccess
{
    public class ConnectionFactory : IDisposable
    {
        private string connectionStringKey;
        private IDbConnection dbConnection;
        private IConfigurationRoot configurationRoot;

        public IDbConnection DbConnection
        {
            get { return dbConnection ?? (dbConnection = new SqlConnection(connectionStringKey)); }
            set { dbConnection = value; }
        }

        public ConnectionFactory()
        {
            configurationRoot = GetConfig();
            connectionStringKey = configurationRoot.GetConnectionString("MedicineDBConnection");
        }

        private IConfigurationRoot GetConfig()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            return builder.Build();
        }

        ~ConnectionFactory()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbConnection.Dispose();
            }
        }
    }
}