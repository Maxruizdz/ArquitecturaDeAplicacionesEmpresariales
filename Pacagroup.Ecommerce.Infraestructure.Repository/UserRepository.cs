using Dapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interfaces;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Pacagroup.Ecommerce.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionsFactory _connectionFactory;

        public UserRepository(IConnectionsFactory connectionFactory)
        {

            _connectionFactory = connectionFactory;

        }

        public Users Authenticate(string Username, string Password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var queries = "UsersGetByUserAndPassword";
                var parameter = new DynamicParameters();

                parameter.Add("@UserName", Username);
                parameter.Add("@Password", Password);



                var result =  connection.QuerySingle<Users>(queries, param: parameter, commandType: CommandType.StoredProcedure);


                return result;
            }
        }
    }
}
