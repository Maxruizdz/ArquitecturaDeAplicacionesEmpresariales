using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interfaces;
using Pacagroup.Ecommerce.Domain.Interfaces;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pacagroup.Ecommerce.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserApplication(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Response<UserDto> Authenticate(string Username, string Password)
        {
            var userBd= _userRepository.Authenticate(Username, Password);

            var ResponseUser= _mapper.Map<UserDto>(userBd);

        }
    }
}
