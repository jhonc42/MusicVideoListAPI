using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Exceptions;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Domain.Core.QueryFilters;
using JAC.MusicVideoList.Transversal.Common.Consts;
using Microsoft.Extensions.Configuration;

namespace JAC.MusicVideoList.Infrastructure.Main.External
{
    public class ExternalServices : IExternalServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _endpoint = Global.SEARCH_YT_ENDPOINT;
        private readonly string _key = Global.GLOBAL_YT_KEY;
        private readonly string _part = Global.SEARCH_YT_PART;
        private readonly string _type = Global.SEARCH_YT_TYPE;
        private readonly string _videoDuration = Global.SEARCH_YT_VIDEO_DURATION;

        public ExternalServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<SearchYTResult> SearchYTByKeyword(SearchQueryFilter filter)
        {
            using (var httpClient = new HttpClient())
            {
                var request = $"{_configuration["URLsSetting:YoutubeAPI"]}{_endpoint}?key={_key}&part={_part}&q={filter.KeyWord}&maxResults={filter.MaxResults}&type={_type}&videoDuration={_videoDuration}";
                var response = await httpClient.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var respString = await response.Content.ReadAsStringAsync();
                    var responseYT = JsonSerializer.Deserialize<SearchYTResult>(respString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return responseYT;
                }
                else
                {
                    throw new BusinessException($"external Api reason failure: {response.ReasonPhrase}");
                }
            }
        }
    }
}
