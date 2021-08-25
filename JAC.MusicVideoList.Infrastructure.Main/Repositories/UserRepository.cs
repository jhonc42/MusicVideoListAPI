using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Infrastructure.Main.Data.ContextMongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Infrastructure.Main.Repositories
{
    //class UserRepository : MongoRepository<User>, IUserRepository
    class UserRepository : IUserRepository
    {
        private readonly IUserContext _userContext;
        public UserRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<User> GetUserByUserName(UserLogin user)
        {
            return await _userContext.Users.Find(x => x.UserName == user.UserName).FirstOrDefaultAsync();
        }

        public async Task RegisterUser(User newUser)
        {
            await _userContext.Users.InsertOneAsync(newUser);
        }
    }
}
