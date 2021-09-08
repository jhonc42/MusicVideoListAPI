using System;
using System.Collections.Generic;
using JAC.MusicVideoList.Domain.Core.Entities.Repository;

namespace JAC.MusicVideoList.Domain.Core.Entities
{
    [BsonCollection("PlayList")]
    public class PlayList : Document
    {
        
        public PlayList()
        {
            ItemPlayList = new List<ItemPlayList>();
        }

        public string Name { get; set; }

        public string User { get; set; }

        public List<ItemPlayList> ItemPlayList { get; set; }
    }
}
