using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacagroup.Ecommerce.Application.Interfaces
{
    public interface IUserApplication
    {
        Response<UserDto> Authenticate(string Username, string Password);

    }
}
