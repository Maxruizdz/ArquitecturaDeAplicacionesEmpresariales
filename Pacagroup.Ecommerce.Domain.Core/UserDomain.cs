using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class UserDomain : IUserDomain
    {

        private readonly IUserRepository _userRepository;

        public UserDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Users Authenticate(string Username, string Password)
        {
            var result= _userRepository.Authenticate(Username, Password);

            return result;

        }
    }
}
