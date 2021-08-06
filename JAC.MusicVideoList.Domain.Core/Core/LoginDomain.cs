using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Domain.Core.Core
{
    public class LoginDomain : ILoginDomain
    {
        public async Task<SecurityUser> GetLoginByCredentials(UserLogin userLogin)
        {
            
            return new SecurityUser { UserName = "Alex", Password = "123456", Role = Enums.RoleType.Administrator, User = "Alex123" };
            // return await _unitOfWork.SecurityRepository.GetLoginByCredentials(userLogin);
        }
    }
}
