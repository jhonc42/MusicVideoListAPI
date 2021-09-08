using System;
using System.Threading.Tasks;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Entities.Repository;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Domain.Core.Interfaces.Repository;

namespace JAC.MusicVideoList.Domain.Core.Core
{
    public class PlayListItemDomain : IPlayListItemDomain
    {
        private readonly IRepository<PlayList> _playListRepository;

        public PlayListItemDomain(IRepository<PlayList> playListRepository)
        {
            _playListRepository = playListRepository;
        }

        public async Task AddItemToPlayList(PlayList item)
        {

            await _playListRepository.ReplaceOneAsync(item);
            // return item.ItemPlayList[^1];

        }

        public async Task AddPlayList(PlayList playList)
        {
            await _playListRepository.InsertOneAsync(playList);
        }

        public async Task DeleteItemFromPlayList(PlayList item)
        {
            await _playListRepository.ReplaceOneAsync(item);
        }

        public async Task<PlayList> GetPlayListById(string id)
        {
            return await _playListRepository.FindByIdAsync(id);
        }
    }
}
