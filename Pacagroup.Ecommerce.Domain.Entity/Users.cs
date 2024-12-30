using System;
using System.Collections.Generic;
using System.Text;

namespace Pacagroup.Ecommerce.Domain.Entity
{
    public class Users
    {

        public int UserId { get; set; }

        public string? FirtName { get; set; }  

        public string? LastName { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Token { get; set; }
    }
}
