using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Domain.Core.Interfaces
{
    // public interface IUserRepository : IMongoRepository<User>
    public interface IUserRepository
    {
        Task<User> GetUserByUserName(UserLogin user);

        Task RegisterUser(User newUser);
    }
}
