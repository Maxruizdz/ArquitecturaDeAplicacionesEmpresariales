using System;
using System.Collections.Generic;
using System.Text;

namespace Pacagroup.Ecommerce.Application.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string? FirtName { get; set; }

        public string? LastName { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Token { get; set; }
    }
}
