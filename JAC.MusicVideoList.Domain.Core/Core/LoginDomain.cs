using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Domain.Core.Interfaces.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Domain.Core.Core
{
    public class LoginDomain : ILoginDomain
    {
        private readonly IRepository<User> _userRepository;
        // private readonly IUnitOfWork _uow;

        // public LoginDomain(IRepository<User> userRepository, IUnitOfWork uow)
        public LoginDomain(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _userRepository.FindOneAsync(
                filter => filter.Email == userLogin.Email
                // x => x.UserName == userLogin.UserName
            );
            // return await _userRepository.GetUserByUserName(userLogin);
            // return await _unitOfWork.SecurityRepository.GetLoginByCredentials(userLogin);
        }
    }
}
