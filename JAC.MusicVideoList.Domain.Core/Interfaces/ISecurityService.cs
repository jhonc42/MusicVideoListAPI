using JAC.MusicVideoList.Domain.Core.Entities;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Domain.Core.Interfaces
{
    public interface ISecurityService
    {
        Task RegisterSecurityUser(User securityUser);
    }
}