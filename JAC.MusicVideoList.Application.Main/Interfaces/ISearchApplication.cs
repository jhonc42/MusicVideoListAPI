using System;
using System.Threading.Tasks;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.QueryFilters;
using JAC.MusicVideoList.Transversal.Common;

namespace JAC.MusicVideoList.Application.Main.Interfaces
{
    public interface ISearchApplication
    {
        Task<Response<SearchYTResult>> SearchByKeyword(SearchQueryFilter user);
    }
}
