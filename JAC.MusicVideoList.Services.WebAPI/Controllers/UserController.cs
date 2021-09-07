using AutoMapper;
using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Enums;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Services.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;
        private readonly IPasswordService _passwordService;
        public UserController(IUserApplication userApplication, IPasswordService passwordService)
        {
            _userApplication = userApplication;
            _passwordService = passwordService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response<IEnumerable<UserTokenDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        // [Authorize]
        public async Task<IActionResult> Post(UserDTO userDTO)
        {

            userDTO.Password = _passwordService.Hash(userDTO.Password);
            var response = await _userApplication.CreateUser(userDTO);
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
