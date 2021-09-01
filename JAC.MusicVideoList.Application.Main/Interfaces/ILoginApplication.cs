using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Domain.Core.Entities;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Application.Main.Interfaces
{
    public interface ILoginApplication
    {
        Task<(bool, UserDTO)> GetLoginByCredentials(UserLogin userLogin);
    }
}
