using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Application.Main.Interfaces
{
    public interface IUserApplication
    {
        Task<Response<UserTokenDTO>> CreateUser(UserDTO user);
    }
}
