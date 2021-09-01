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
            var response = new Response<UserTokenDTO>();
            try
            {
                var user = _mapper.Map<User>(userDTO);
                await _userDomain.RegisterSecurityUser(user);
                //TODO mejorar esto con lo de abajo
                return new Response<UserTokenDTO> { IsSuccess = true, Data = _mapper.Map<UserTokenDTO>(user), Message = "OK" };
            }
            catch (Exception ex)
            {
                //TODO mejorar esto con lo de arriba
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;


        }
    }
}
