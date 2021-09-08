using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Entities.Repository;
using JAC.MusicVideoList.Transversal.Common;

namespace JAC.MusicVideoList.Application.Main.Interfaces
{
    public interface IPlayListItemApplication
    {
        Task<Response<PlayList>> AddItemToPlayList(ItemPlayList item);
        Task<Response<PlayList>> AddPlayList(PlayList playList);
        Task<Response<bool>> DeleteItemFromPlayList(string listId, string itemId);
        // Task<Response<List<ItemList>>> GetItemPlayList();
        Task<Response<PlayList>> GetPlayListById(string id);
    }
}
