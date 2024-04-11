using Pacagroup.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Infraestructure.Interface
{
    public interface ICustomerRepository
    {
        bool Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(string id);


        Customer Get(string id);

        IEnumerable<Customer> GetAll();


      Task<bool> InsertAsync(Customer customer);
       Task <bool> UpdateAsync(Customer customer);
      Task<bool> DeleteAsync(string id);


      Task<Customer> GetAsync(string id);

        Task<IEnumerable<Customer>> GetAllAsync();

    }
}
