using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interfaces;
using Pacagroup.Ecommerce.Services.WebApi.Helpers;
using Pacagroup.Ecommerce.Transversal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserApplication _userApplication;
        private readonly AppSettings _appSetting;

        public UserController(IUserApplication userApplication, IOptions<AppSettings> appSetting)
        {
            _userApplication = userApplication;
            _appSetting = appSetting.Value;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserDto userDto)
        {
            var response = _userApplication.Authenticate(userDto.Username, userDto.Password);

            if (response.IsSuccess)
            {


                if (response != null)
                {
                    response.Data.Token = BuildToken(response);

                    return Ok(response);

                }
                return NotFound(response);
            
            
            }

            return BadRequest(response);



        }


       
            private string BuildToken(Response<UserDto> usuarioDto)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                  new Claim(ClaimTypes.Name, usuarioDto.Data.UserId.ToString()),
                  
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _appSetting.Issuer,
                    Audience = _appSetting.Audience
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return tokenString;
            }





        }
    
}
