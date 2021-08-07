using AutoMapper;
using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Application.Main.Main
{
    public class LoginApplication : ILoginApplication
    {
        private readonly ILoginDomain _loginDomain;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public LoginApplication(ILoginDomain loginDomain, IMapper mapper, IPasswordService passwordService)
        {
            _loginDomain = loginDomain;
            _mapper = mapper;
            _passwordService = passwordService;
        }
        public async Task<(bool, SecurityUserDTO)> GetLoginByCredentials(UserLogin userLogin)
        {
            // TODO exceptions manage
            var user = await _loginDomain.GetLoginByCredentials(userLogin);
            if (user == null)
                return (false, _mapper.Map<SecurityUserDTO>(user));

            var isValid = _passwordService.Check(user.Password, userLogin.Password);
            return (isValid, _mapper.Map<SecurityUserDTO>(user));
        }
    }
}
