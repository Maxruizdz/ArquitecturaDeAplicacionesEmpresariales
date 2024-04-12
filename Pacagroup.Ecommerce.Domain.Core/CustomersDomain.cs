using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interfaces;
using Pacagroup.Ecommerce.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class CustomersDomain : ICustomerDomain
    {
        private readonly ICustomerRepository _customersRepository;

        public CustomersDomain(ICustomerRepository customersRepository)
        {

            _customersRepository = customersRepository;
        }


        #region metodos Sincronos

        public bool Insert(Customer customer) 
        {
        
        return   _customersRepository.Insert(customer);
       
        
        }

        public bool Update(Customer customer)
        {

            return _customersRepository.Update(customer);
        }
        public bool Delete(string id ) 
        { 
        

            return _customersRepository.Delete(id);
        
        
        }

        public Customer Get(string id)
        {


            return _customersRepository.Get(id);    
        }
        public IEnumerable<Customer> GetAll( ) 
        {

            return _customersRepository.GetAll();
        
        }

        #endregion

        #region metodos Asyncronos


        public async Task<bool> InsertAsync(Customer customer)
        {

            return await _customersRepository.InsertAsync(customer);


        }

        public async Task<bool> UpdateAsync(Customer customer)
        {

            return  await _customersRepository.UpdateAsync(customer);
        }
        public async Task<bool> DeleteAsync(string id)
        {


            return await _customersRepository.DeleteAsync(id);


        }

        public  async Task<Customer> GetAsync(string id)
        {


            return await _customersRepository.GetAsync(id);
        }
        public Task<IEnumerable<Customer>> GetAllAsync()
        {

            return _customersRepository.GetAllAsync();

        }



        #endregion


    }
}
