using AutoMapper;
using Microsoft.Win32.SafeHandles;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interfaces;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interfaces;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Main
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly ICustomerDomain _customerDomain;
        private readonly IMapper _mapper;

        public CustomersApplication(ICustomerDomain customerDomain, IMapper mapper)
        {

            _customerDomain = customerDomain;
            _mapper = mapper;

        }
        public Response<bool> Insert(CustomersDto customerDto)
        {
            var response = new Response<bool>();

            try
            {

                var customer = _mapper.Map<Customer>(customerDto);

                response.Data = _customerDomain.Insert(customer);
                if (response.Data)
                {

                    response.IsSuccess = true;
                    response.Message = "Registro Existoso";
                }



            }
            catch (Exception e)
            {
                response.Message = e.Message;



            }
            return response;

        }
        public Response<bool> Update(CustomersDto customerDto)
        {
            var response = new Response<bool>();

            try
            {

                var customer = _mapper.Map<Customer>(customerDto);

                response.Data = _customerDomain.Update(customer);
                if (response.Data)
                {

                    response.IsSuccess = true;
                    response.Message = "Actualizacion de usuario Existosa";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }

            return response;


        }
        public Response<bool> Delete(string id)
        {
            var response = new Response<bool>();
            try
            {

                response.Data = _customerDomain.Delete(id);

                if (response.Data)
                {
                    response.Message = "Se ha eliminado el usuario correctamente";
                    response.IsSuccess = true;

                }


            }
            catch (Exception e)
            {

                response.Message = e.Message;

            }

            return response;

        }


        public Response<CustomersDto> Get(string id)
        {

            var response = new Response<CustomersDto>();

            try
            {

                var customerId = _customerDomain.Get(id);
                response.Data = _mapper.Map<CustomersDto>(customerId);
                if (response.Data != null)
                {
                    response.Message = "Se ha encontrado el usuario";
                    response.IsSuccess = true;


                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }


            return response;
        }

      public  Response<IEnumerable<CustomersDto>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDto>>();
            try
            {
                var customersList = _customerDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customersList);

                if (response.Data != null)
                {

                    response.IsSuccess = true;
                    response.Message = "Se ha mostrado todos los usuarios exitosamente";


                }


            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }



            return response;
        }


        public async Task<Response<bool>> InsertAsync(CustomersDto customerDto)
        {
            var response = new Response<bool>();

            try
            {

                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customerDomain.InsertAsync(customer);

                if (response.Data)
                {
                    response.Message = "Se ha agregado al usuario exitosamente";
                    response.IsSuccess = true;

                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;


            }




            return response;
        }
        public async Task<Response<bool>> UpdateAsync(CustomersDto customerDto)
        {
            var response = new Response<bool>();

            try
            {

                var customer = _mapper.Map<Customer>(customerDto);

                response.Data = await _customerDomain.UpdateAsync(customer);
                if (response.Data)
                {

                    response.IsSuccess = true;
                    response.Message = "Actualizacion de usuario Existosa";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }

            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string id)
        {
            var response = new Response<bool>();
            try
            {

                response.Data = await _customerDomain.DeleteAsync(id);

                if (response.Data)
                {
                    response.Message = "Se ha eliminado el usuario correctamente";
                    response.IsSuccess = true;

                }


            }
            catch (Exception e)
            {

                response.Message = e.Message;

            }

            return response;



        }


        public async Task<Response<CustomersDto>> GetAsync(string id)
        {
            var response = new Response<CustomersDto>();

            try
            {

                var customerId = await _customerDomain.GetAsync(id);
                response.Data = _mapper.Map<CustomersDto>(customerId);
                if (response.Data != null)
                {
                    response.Message = "Se ha encontrado el usuario";
                    response.IsSuccess = true;


                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }


            return response;







        }

        public async Task<Response<IEnumerable<CustomersDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDto>>();
            try
            {
                var customersList = await _customerDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customersList);

                if (response.Data != null)
                {

                    response.IsSuccess = true;
                    response.Message = "Se ha mostrado todos los usuarios exitosamente";


                }




            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }

            return response;
        }

    }
}
