using AutoMapper;
using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Application.Main.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        public UserApplication(IUserDomain userDomain, IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }
        public async Task<Response<UserTokenDTO>> CreateUser(UserDTO userDTO)
        {
            //TODO mirar manejo de filtros de excepciones
            try
            {
                var user = _mapper.Map<User>(userDTO);
                await _userDomain.RegisterSecurityUser(user);
                return Response<UserTokenDTO>.CreateSuccessful(_mapper.Map<UserTokenDTO>(user));
            }
            catch (Exception ex)
            {
                return Response<UserTokenDTO>.CreateUnsuccessful(ex.Message, null);
            }

        }
    }
}
