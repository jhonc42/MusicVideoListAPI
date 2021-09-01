using AutoMapper;
using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Services.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
