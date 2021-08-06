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
        public LoginApplication(ILoginDomain loginDomain, IMapper mapper)
        {
            _loginDomain = loginDomain;
            _mapper = mapper;
        }
        public async Task<SecurityUserDTO> GetLoginByCredentials(UserLogin userLogin)
        {
            // TO DO
            var user = await _loginDomain.GetLoginByCredentials(userLogin);
            return _mapper.Map<SecurityUserDTO>(user);
        }
    }
}
