using Microsoft.Extensions.Configuration;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Pacagroup.Ecommerce.Infraestructura.Data
{
    public class ConnectionFactory : IConnectionsFactory
    {
        private readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        public IDbConnection GetConnection {

            get {


                var sqlconnection = new SqlConnection();
                if (sqlconnection == null)
                    return null;
                sqlconnection.ConnectionString = _configuration.GetConnectionString("NortwindConnection");
                sqlconnection.Open();

                return sqlconnection;
            }
        }
    }
}
