using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WhoruBackend.ModelViews.FeedModelViews;
using WhoruBackend.Services;
using WhoruBackend.Services.Implement;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [Route("api/v1/[controller]s/[action]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IFeedService _feedService;
        private readonly IUserService _userService;
        public FeedController(IFeedService feedService, IUserService userService)
        {
            _feedService = feedService;
            _userService = userService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] NewFeedModelView feed)
        {
            var id = await _userService.GetIdByToken();
            if (feed == null || feed.Status == null)
            {
                return BadRequest();
            }
            var post = await _feedService.Create(id, feed.Status, feed.Files, feed.State);
            return Ok(post);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateFeedStatus([FromBody] FeedStatusModelView view)
        {
            var response = await _feedService.UpdateFeedStatus(view.idPost, view.status);
            if (response.Message == MessageConstant.UPDATE_SUCCESS)
                return Ok(response);
            if(response.Message == MessageConstant.SYSTEM_ERROR)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return BadRequest();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var response =await _feedService.Delete(id);
            if(response.Message == MessageConstant.NOT_FOUND)
            {
                return NotFound();
            }
            else
            {
                if(response.Message == MessageConstant.SYSTEM_ERROR)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return Ok(response);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetAllPost([FromBody] int page)
        {
            var list = await _feedService.GetAllFeed(page);
            if (list.Count <= 0)
                return NotFound();
            return Ok(list);
        }


        [Authorize]
        [HttpPost]
        public async  Task<IActionResult> GetAllPostById([FromBody] FindFeedModelView view)
        {
            var list = await _feedService.GetAllFeedByUserId(view.id,view.page);
            if (list.Count <= 0)
                return NotFound();
            return Ok(list);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetPostById([FromBody] int postId)
        {
            var feed = await _feedService.GetFeedById(postId);
            if (feed == null)
            {
                return NotFound();
            }
            return Ok(feed);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetAllSharedPost([FromBody] FindFeedModelView view)
        {
            var list = await _feedService.GetAllSharedPost(view.id, view.page);
            if (list.Count <= 0)
                return NotFound();
            return Ok(list);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SearchPost([FromBody] SearchFeedModelView view)
        {
            if (view.keyword == string.Empty)
            {
                return NotFound();
            }

            var info = await _feedService.SearchFeed(view.keyword,view.page);
            if (info == null)
            {
                return NotFound();
            }

            return Ok(info);
        }
    }
}
