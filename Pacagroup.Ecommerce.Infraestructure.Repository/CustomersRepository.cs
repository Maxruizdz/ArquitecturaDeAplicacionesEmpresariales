using Dapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infraestructure.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Infraestructure.Repository
{
    public class CustomersRepository : ICustomerRepository
    {

        private readonly IConnectionFactory _connectionFactory;

        public CustomersRepository(IConnectionFactory connectionFactory) { 
        
        _connectionFactory = connectionFactory; 
        
        }

        public bool Delete(string id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var queries = "CustomersDelete";
                var parameter = new DynamicParameters();

                parameter.Add("CustomerID",id);
           
             

                var result = connection.Execute(queries, param: parameter, commandType: CommandType.StoredProcedure);



                return result > 0;

            }
        }

    
        public Customer Get(string id)
        {
              using (var connection = _connectionFactory.GetConnection) {
            
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", id);
                var customer = connection.QuerySingle<Customer>(query, param: parameters , commandType: CommandType.StoredProcedure);


                return customer;
        }

        }


        public IEnumerable<Customer> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var query = "CustomersList";

                var customer = connection.Query<Customer>(query, commandType: CommandType.StoredProcedure);


                return customer;
            } }



      
        public bool Insert(Customer customer)
        {
            using (var connection = _connectionFactory.GetConnection) 
            {

                var queries = "CustomersInsert";
                var parameter = new DynamicParameters();

                parameter.Add("CustomerID", customer.CustomerId);
                parameter.Add("CompanyName", customer.CompanyName);
                parameter.Add("ContactName", customer.ContactName);
                parameter.Add("ContactTitle", customer.ContactTitle);
                parameter.Add("Address", customer.Address);
                parameter.Add("City", customer.City);
                parameter.Add("Region", customer.Region);
                parameter.Add("PostalCode", customer.PostalCode);
                parameter.Add("Country", customer.Country);
                parameter.Add("Phone", customer.Phone);
                parameter.Add("Fax", customer.Fax);

                var result = connection.Execute(queries, param: parameter, commandType: CommandType.StoredProcedure);



                return result > 0;
            
            }
        }

        

        public bool Update(Customer customer)
        {

            using (var connection = _connectionFactory.GetConnection)
            {

                var queries = "CustomersUpdate";
                var parameter = new DynamicParameters();

                parameter.Add("CustomerID", customer.CustomerId);
                parameter.Add("CompanyName", customer.CompanyName);
                parameter.Add("ContactName", customer.ContactName);
                parameter.Add("ContactTitle", customer.ContactTitle);
                parameter.Add("Address", customer.Address);
                parameter.Add("City", customer.City);
                parameter.Add("Region", customer.Region);
                parameter.Add("PostalCode", customer.PostalCode);
                parameter.Add("Country", customer.Country);
                parameter.Add("Phone", customer.Phone);
                parameter.Add("Fax", customer.Fax);

                var result = connection.Execute(queries, param: parameter, commandType: CommandType.StoredProcedure);



                return result > 0;
            }
        }




        public async Task<bool> DeleteAsync(string id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var queries = "CustomersDelete";
                var parameter = new DynamicParameters();

                parameter.Add("CustomerID", id);



                var result = await connection.ExecuteAsync(queries, param: parameter, commandType: CommandType.StoredProcedure);



                return result > 0;

            }
        }


        public async Task<Customer >GetAsync(string id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", id);
                var customer =await  connection.QuerySingleAsync<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);


                return customer;
            }

        }


        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var query = "CustomersList";

                var customer =await connection.QueryAsync<Customer>(query, commandType: CommandType.StoredProcedure);


                return customer;
            }
        }




        public async Task<bool> InsertAsync(Customer customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var queries = "CustomersInsert";
                var parameter = new DynamicParameters();

                parameter.Add("CustomerID", customer.CustomerId);
                parameter.Add("CompanyName", customer.CompanyName);
                parameter.Add("ContactName", customer.ContactName);
                parameter.Add("ContactTitle", customer.ContactTitle);
                parameter.Add("Address", customer.Address);
                parameter.Add("City", customer.City);
                parameter.Add("Region", customer.Region);
                parameter.Add("PostalCode", customer.PostalCode);
                parameter.Add("Country", customer.Country);
                parameter.Add("Phone", customer.Phone);
                parameter.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(queries, param: parameter, commandType: CommandType.StoredProcedure);



                return result > 0;

            }
        }



        public async Task<bool> UpdateAsync(Customer customer)
        {

            using (var connection = _connectionFactory.GetConnection)
            {

                var queries = "CustomersUpdate";
                var parameter = new DynamicParameters();

                parameter.Add("CustomerID", customer.CustomerId);
                parameter.Add("CompanyName", customer.CompanyName);
                parameter.Add("ContactName", customer.ContactName);
                parameter.Add("ContactTitle", customer.ContactTitle);
                parameter.Add("Address", customer.Address);
                parameter.Add("City", customer.City);
                parameter.Add("Region", customer.Region);
                parameter.Add("PostalCode", customer.PostalCode);
                parameter.Add("Country", customer.Country);
                parameter.Add("Phone", customer.Phone);
                parameter.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(queries, param: parameter, commandType: CommandType.StoredProcedure);



                return result > 0;
            }
        }

    }
}
