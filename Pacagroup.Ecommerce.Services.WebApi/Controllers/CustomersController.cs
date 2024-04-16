using Microsoft.AspNetCore.Mvc;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interfaces;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers
{

    public class CustomersController : Controller
    {

        private ICustomersApplication _customerApplication;

        public CustomersController(ICustomersApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }


        #region metodos sincronos

        [HttpPost]

        public IActionResult Insert([FromBody]CustomersDto customersDto) 
        {

            if (customersDto == null)
            
                return BadRequest();

          var result=   _customerApplication.Insert(customersDto);

            if (!result.IsSuccess)

                return BadRequest(result.Message);



            return Ok();


        }
        [HttpPut]

        public IActionResult Update([FromBody]CustomersDto customersDto)
        {

            if (customersDto == null)

                return BadRequest();

            var result = _customerApplication.Update(customersDto);

            if (!result.IsSuccess)

                return BadRequest(result.Message);



            return Ok();


        }
     
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
           
            if (id is null)
                return BadRequest();

            var result = _customerApplication.Delete(id);

            if (!result.IsSuccess)

                return BadRequest(result.Message);



            return Ok();


        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {

            if (string.IsNullOrEmpty(id)) 
                return BadRequest();

            var customer= _customerApplication.Get(id);

            if (customer.IsSuccess) 
            {

                return Ok(customer);
            
            }


            return BadRequest(customer.Message);


        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {


            var customer = _customerApplication.GetAll();

            if (customer.IsSuccess)
            {

                return Ok(customer.Data.ToList());

            }


            return BadRequest(customer.Message);


        }



        #endregion


        [HttpPost("Async")]

        public async Task<IActionResult> InsertAsync([FromBody] CustomersDto customersDto)
        {

            if (customersDto == null)

                return BadRequest();

            var result =  await _customerApplication.InsertAsync(customersDto);

            if (!result.IsSuccess)

                return BadRequest(result.Message);



            return Ok();


        }
        [HttpPut("Async")]

        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDto customersDto)
        {

            if (customersDto == null)

                return BadRequest();

            var result = await _customerApplication.UpdateAsync(customersDto);

            if (!result.IsSuccess)

                return BadRequest(result.Message);



            return Ok();


        }

        [HttpDelete("Async/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {

            if (id is null)
                return BadRequest();

            var result = await _customerApplication.DeleteAsync(id);

            if (!result.IsSuccess)

                return BadRequest(result.Message);



            return Ok();


        }
        [HttpGet("Async/{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {

            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var customer = await _customerApplication.GetAsync(id);

            if (customer.IsSuccess)
            {

                return Ok(customer);

            }


            return BadRequest(customer.Message);


        }
        [HttpGet("Async/All")]
        public async Task<IActionResult> GetAllAsync()
        {


            var customer = await _customerApplication.GetAllAsync();

            if (customer.IsSuccess)
            {

                return Ok(customer.Data.ToList());

            }


            return BadRequest(customer.Message);


        }

        public IActionResult Index()
        {
            return View();
        }


        
    }
}
