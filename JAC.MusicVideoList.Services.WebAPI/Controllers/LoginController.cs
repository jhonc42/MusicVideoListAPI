using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Services.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginApplication _loginApplication;

        public LoginController(IConfiguration configuration, ILoginApplication loginApplication)
        {
            _configuration = configuration;
            _loginApplication = loginApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            //if it is a valid user
            var response = await _loginApplication.GetLoginByCredentials(login);
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }
            response.Data.Token = GenerateToken(response.Data);
            return Ok(response);
        }

        private string GenerateToken(UserTokenDTO user)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("User", user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
