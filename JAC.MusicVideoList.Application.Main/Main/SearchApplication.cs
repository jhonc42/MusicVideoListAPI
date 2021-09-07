using System;
using System.Threading.Tasks;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Domain.Core.QueryFilters;
using JAC.MusicVideoList.Transversal.Common;

namespace JAC.MusicVideoList.Application.Main.Main
{
    public class SearchApplication : ISearchApplication
    {
        private readonly ISearchDomain _searchDomain;

        public SearchApplication(ISearchDomain searchDomain)
        {
            _searchDomain = searchDomain;
        }

        public async Task<Response<SearchYTResult>> SearchByKeyword(SearchQueryFilter filter)
        {
            try
            {
                var result = await _searchDomain.SearchByKeyword(filter);
                return Response<SearchYTResult>.CreateSuccessful(result);
            }
            catch (Exception ex)
            {
                return Response<SearchYTResult>.CreateUnsuccessful(ex.Message, null);
            }

        }
    }
}
