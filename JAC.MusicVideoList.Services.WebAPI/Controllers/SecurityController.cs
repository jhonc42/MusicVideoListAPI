using AutoMapper;
using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Services.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public SecurityController(ISecurityService securityService, IMapper mapper, IPasswordService passwordService)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SecurityUserDTO securityUserDTO)
        {
            var securityUser = _mapper.Map<SecurityUser>(securityUserDTO);

            securityUser.Password = _passwordService.Hash(securityUser.Password);
            await _securityService.RegisterSecurityUser(securityUser);

            // TODO create ApiResponse:
            // var response = new ApiResponse<SecurityUserDTO>(securityUserDTO);
            return Ok();
        }
    }
}
