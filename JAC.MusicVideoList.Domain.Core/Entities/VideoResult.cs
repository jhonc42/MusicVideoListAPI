using System;
using Newtonsoft.Json;

namespace JAC.MusicVideoList.Domain.Core.Entities
{
    public class VideoResult
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("snippet")]
        public Snippet Snippet { get; set; }
    }
    //public partial class Id
    //{
    //    [JsonProperty("kind")]
    //    public string Kind { get; set; }

    //    [JsonProperty("videoId")]
    //    public string VideoId { get; set; }
    //}

    //public partial class Snippet
    //{
    //    [JsonProperty("publishedAt")]
    //    public DateTimeOffset PublishedAt { get; set; }

    //    [JsonProperty("channelId")]
    //    public string ChannelId { get; set; }

    //    [JsonProperty("title")]
    //    public string Title { get; set; }

    //    [JsonProperty("description")]
    //    public string Description { get; set; }

    //    [JsonProperty("thumbnails")]
    //    public Thumbnails Thumbnails { get; set; }

    //    [JsonProperty("channelTitle")]
    //    public string ChannelTitle { get; set; }

    //    [JsonProperty("liveBroadcastContent")]
    //    public string LiveBroadcastContent { get; set; }

    //    [JsonProperty("publishTime")]
    //    public DateTimeOffset PublishTime { get; set; }
    //}

    //public partial class Thumbnails
    //{
    //    [JsonProperty("default")]
    //    public Default Default { get; set; }

    //    [JsonProperty("medium")]
    //    public Default Medium { get; set; }

    //    [JsonProperty("high")]
    //    public Default High { get; set; }
    //}

    //public partial class Default
    //{
    //    [JsonProperty("url")]
    //    public Uri Url { get; set; }

    //    [JsonProperty("width")]
    //    public long Width { get; set; }

    //    [JsonProperty("height")]
    //    public long Height { get; set; }
    //}
}
