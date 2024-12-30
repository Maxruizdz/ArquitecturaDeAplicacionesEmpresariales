using Pacagroup.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacagroup.Ecommerce.Domain.Interfaces
{
    public interface IUserDomain
    {
        Users Authenticate(string Username, string Password);

    }
}
