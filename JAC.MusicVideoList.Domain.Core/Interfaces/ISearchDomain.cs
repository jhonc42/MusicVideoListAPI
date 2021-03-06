using System;
using System.Threading.Tasks;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.QueryFilters;

namespace JAC.MusicVideoList.Domain.Core.Interfaces
{
    public interface ISearchDomain
    {
        Task<SearchYTResult> SearchByKeyword(SearchQueryFilter securityUser);
    }
}
