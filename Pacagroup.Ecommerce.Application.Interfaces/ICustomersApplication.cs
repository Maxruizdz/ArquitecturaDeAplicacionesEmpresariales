using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interfaces
{
    public interface ICustomersApplication
    {

       Response <bool> Insert(CustomersDto customer);
        Response<bool> Update(CustomersDto customer);
        Response<bool> Delete(string id);


        Response <CustomersDto> Get(string id);

       Response <IEnumerable<CustomersDto>> GetAll();


   Task<Response<bool>> InsertAsync(CustomersDto customer);
       Task <Response<bool>> UpdateAsync(CustomersDto customer);
        Task<Response<bool>> DeleteAsync(string id);


      Task<Response<CustomersDto>> GetAsync(string id);

        Task<Response<IEnumerable<CustomersDto>>> GetAllAsync();
    }
}
