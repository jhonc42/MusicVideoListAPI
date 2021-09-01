using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Domain.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Domain.Core.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IRepository<User> _userRepository;

        public UserDomain(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task RegisterSecurityUser(User user)
        {
            await _userRepository.InsertOneAsync(user);
        }
    }
}
