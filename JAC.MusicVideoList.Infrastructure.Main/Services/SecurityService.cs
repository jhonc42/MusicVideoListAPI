using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Infrastructure.Main.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUserRepository _userRepository;

        public SecurityService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task RegisterSecurityUser(SecurityUser securityUser)
        {
            await _userRepository.RegisterUser(securityUser);

        }
    }
}
