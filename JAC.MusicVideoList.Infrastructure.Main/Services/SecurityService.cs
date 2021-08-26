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
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _uow;

        public SecurityService(IRepository<User> userRepository, IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _uow = uow;
        }
        public async Task RegisterSecurityUser(User securityUser)
        {
            _userRepository.InsertOne(securityUser);
            await _uow.Commit();

        }
    }
}
