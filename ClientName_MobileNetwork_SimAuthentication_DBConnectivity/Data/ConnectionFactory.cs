using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
namespace ClientName_MobileNetwork_SimAuthentication_DBConnectivity.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _config;

        public ConnectionFactory(IConfiguration config)
        {
                _config = config;
        }
        public IDbConnection GetHotelManagementSqlConnection()
        {
            IDbConnection _connection = new SqlConnection(Convert.ToString(_config.GetSection("ConnectionStrings:hotelmanagementSqlConnectionString").Value));

            return _connection;
        }
    }
}
