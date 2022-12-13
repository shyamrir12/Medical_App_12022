

using System.Data;
using System.Data.SqlClient;

namespace Medical_App_1.Server.Factory
{
     public class ConnectionFactory : IConnectionFactoryAuthDB,IConnectionFactoryMedicalDB
    {
     
        private readonly string _connectionString;

      
        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection => new SqlConnection(_connectionString);
    }
}
