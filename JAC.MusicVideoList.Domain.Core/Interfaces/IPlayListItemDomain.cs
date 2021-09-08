using System;
using System.Threading.Tasks;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Entities.Repository;

namespace JAC.MusicVideoList.Domain.Core.Interfaces
{
    public interface IPlayListItemDomain
    {
        Task AddItemToPlayList(PlayList item);
        Task AddPlayList(PlayList playList);
        Task DeleteItemFromPlayList(PlayList idYT);
        // Task<Response<List<ItemList>>> GetItemPlayList();
        Task<PlayList> GetPlayListById(string id);
    }
}
