using System.Net;
using System.Threading.Tasks;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Entities.Repository;
using JAC.MusicVideoList.Domain.Core.Enums;
using JAC.MusicVideoList.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JAC.MusicVideoList.Services.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    [Produces("application/json")]
    [ApiController]
    public class PlayListItemController : ControllerBase
    {
        private readonly IPlayListItemApplication _PlayListItemApplication;
        public PlayListItemController(IPlayListItemApplication PlayListItemApplication)
        {
            _PlayListItemApplication = PlayListItemApplication;
        }

        [HttpGet, Route("GetPlayList/{listId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response<PlayList>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlayList(string listId)
        {
            var response = await _PlayListItemApplication.GetPlayListById(listId);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost, Route("InsertPlayList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response<PlayList>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Authorize(Roles = nameof(RoleType.Administrator))]
        public async Task<IActionResult> InsertPlayList([FromBody] PlayList playList)
        {
            var response = await _PlayListItemApplication.AddPlayList(playList);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);

           
        }

        [HttpPost, Route("InsertItemPlayList")]
        //[HttpPut(Name = nameof(InsertItemPlayList))]
        //[Route("InsertItemPlayList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response<PlayList>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertItemPlayList([FromBody] ItemPlayList itemPlayList)
        {
            var response = await _PlayListItemApplication.AddItemToPlayList(itemPlayList);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete, Route("DeleteItemPlayList/{listId}/{itemId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Authorize(Roles = nameof(RoleType.Administrator))]
        public async Task<IActionResult> DeleteItemPlayList(string listId, string itemId)
        {
            var response = await _PlayListItemApplication.DeleteItemFromPlayList(listId, itemId);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}