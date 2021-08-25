using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Domain.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Infrastructure.Main.Services
{
    public class SecurityService : ISecurityService
    {
        // private readonly IUserRepository _userRepository;
        private readonly IMongoRepository<User> _userRepository;

        public SecurityService(IMongoRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task RegisterSecurityUser(User securityUser)
        {
            await _userRepository.InsertOneAsync(securityUser);

        }
    }
}
