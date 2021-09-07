using System;
namespace JAC.MusicVideoList.Domain.Core.QueryFilters
{
    public class SearchQueryFilter
    {

        public string KeyWord { get; set; }

        public int MaxResults { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
