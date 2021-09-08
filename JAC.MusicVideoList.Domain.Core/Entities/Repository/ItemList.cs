using System;
namespace JAC.MusicVideoList.Domain.Core.Entities.Repository
{
    public class ItemPlayList
    {
        public ItemPlayList()
        {
        }

        public string IdYT { get; set; }
        public string IdPlayList { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EmbedHtml { get; set; }
        public ContentDetails ContentDetail { get; set; }
        public Thumbnails Thumbnails { get; set; }

    }

    public class ContentDetails
    {
        public string Duration { get; set; }
        public string Dimension { get; set; }
    }
}
