using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Domain.Core.QueryFilters;

namespace JAC.MusicVideoList.Domain.Core.Core
{
    public class SearchDomain : ISearchDomain
    {

        private readonly IExternalServices _externalServices;

        public SearchDomain(IExternalServices externalServices)
        {
            _externalServices = externalServices;
        }

        public async Task<SearchYTResult> SearchByKeyword(SearchQueryFilter filter)
        {
            return await _externalServices.SearchYTByKeyword(filter);
        }
    }
}
