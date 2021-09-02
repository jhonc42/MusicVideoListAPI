using System;
using System.Threading.Tasks;
using AutoMapper;
using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Transversal.Common;

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
        public async Task<Response<UserTokenDTO>> GetLoginByCredentials(UserLogin userLogin)
        {
            // TODO exceptions manage
            try
            {
                var user = await _loginDomain.GetLoginByCredentials(userLogin);
                var userToken = _mapper.Map<UserTokenDTO>(user);
                if (user == null)
                    return Response<UserTokenDTO>.CreateUnsuccessful("Data Login Incorrect", null);

                var isValid = _passwordService.Check(user.Password, userLogin.Password);

                if (isValid)
                    return Response<UserTokenDTO>.CreateSuccessful(userToken);

                return Response<UserTokenDTO>.CreateUnsuccessful("Data Login Incorrect", null);
            }
            catch (Exception ex)
            {
                return Response<UserTokenDTO>.CreateUnsuccessful(ex.Message, null);
            }
            
        }

       
    }
}
