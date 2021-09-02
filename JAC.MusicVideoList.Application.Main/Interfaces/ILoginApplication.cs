using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Transversal.Common;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Application.Main.Interfaces
{
    public interface ILoginApplication
    {
        Task<Response<UserTokenDTO>> GetLoginByCredentials(UserLogin userLogin);
    }
}
