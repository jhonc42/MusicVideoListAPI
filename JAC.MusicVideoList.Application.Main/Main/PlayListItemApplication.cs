using System;
using System.Threading.Tasks;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Entities.Repository;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Transversal.Common;

namespace JAC.MusicVideoList.Application.Main.Main
{
    public class PlayListItemApplication : IPlayListItemApplication
    {
        
        private readonly IPlayListItemDomain _PlayListItemDomain;

        public PlayListItemApplication(IPlayListItemDomain PlayListItemDomain)
        {
            _PlayListItemDomain = PlayListItemDomain;
        }

        public async Task<Response<PlayList>> AddItemToPlayList(ItemPlayList item)
        {
            try
            {
                var playList = await _PlayListItemDomain.GetPlayListById(item.IdPlayList);
                if (playList == null)
                    return Response<PlayList>.CreateUnsuccessful("PlayList Not Found", null);

                playList.ItemPlayList.Add(item);
                await _PlayListItemDomain.AddItemToPlayList(playList);
                return Response<PlayList>.CreateSuccessful(playList);
            }
            catch (Exception ex)
            {
                return Response<PlayList>.CreateUnsuccessful(ex.Message, null);
            }
        }

        public async Task<Response<PlayList>> AddPlayList(PlayList playList)
        {
            try
            {
                await _PlayListItemDomain.AddPlayList(playList);
                return Response<PlayList>.CreateSuccessful(playList);
            }
            catch (Exception ex)
            {
                return Response<PlayList>.CreateUnsuccessful(ex.Message, null);
            }
        }

        public async Task<Response<bool>> DeleteItemFromPlayList(string listId, string itemId)
        {
            try
            {
                var playList = await _PlayListItemDomain.GetPlayListById(listId);
                if (playList == null)
                    return Response<bool>.CreateUnsuccessful("PlayList Not Found", null);

                var itemToRemove = playList.ItemPlayList.Find(x => x.IdYT == itemId);
                if (itemToRemove == null)
                    return Response<bool>.CreateUnsuccessful("Item Not Found", null);

                playList.ItemPlayList.Remove(itemToRemove);

                await _PlayListItemDomain.DeleteItemFromPlayList(playList);
                return Response<bool>.CreateSuccessful(true);
            }
            catch (Exception ex)
            {
                return Response<bool>.CreateUnsuccessful(ex.Message, null);
            }
        }

        public async Task<Response<PlayList>> GetPlayListById(string id)
        {
            try
            {
                var result = await _PlayListItemDomain.GetPlayListById(id);
                if (result == null)
                    return Response<PlayList>.CreateUnsuccessful("List not found", null);

                return Response<PlayList>.CreateSuccessful(result);
            }
            catch (Exception ex)
            {
                return Response<PlayList>.CreateUnsuccessful(ex.Message, null);
            }
        }
    }
}
