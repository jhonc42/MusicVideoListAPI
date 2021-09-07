using System.Net;
using System.Threading.Tasks;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.QueryFilters;
using JAC.MusicVideoList.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JAC.MusicVideoList.Services.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    [Produces("application/json")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchApplication _searchApplication;
        public SearchController(ISearchApplication searchApplication)
        {
            _searchApplication = searchApplication;
        }

        [HttpGet(Name = nameof(SearchByKeyword))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response<SearchYTResult>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SearchByKeyword([FromQuery] SearchQueryFilter filters)
        {
            var response = await _searchApplication.SearchByKeyword(filters);
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}