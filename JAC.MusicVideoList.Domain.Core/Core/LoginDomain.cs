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
        private readonly IUserRepository _userRepository;

        public LoginDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<SecurityUser> GetLoginByCredentials(UserLogin userLogin)
        {
            //var users = new List<SecurityUser> {
            //    new SecurityUser { 
            //        UserName = "jhon123", 
            //        Password = "10000.nOiuuiDjRisPjakggdgsaQ==.gPsty6/HcMi2GSuj/VZdJly0lX1QsD+zl+ovaqM6AVo=", 
            //        Role = Enums.RoleType.Administrator, 
            //        User = "jhon" 
            //    }
            //};

            return await _userRepository.GetUserByUserName(userLogin);
            // return await _unitOfWork.SecurityRepository.GetLoginByCredentials(userLogin);
        }
    }
}
