using JAC.MusicVideoList.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Domain.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<SecurityUser>> GetUsers();

        Task<SecurityUser> GetUserByUserName(UserLogin user);

        Task RegisterUser(SecurityUser newUser);
    }
}
