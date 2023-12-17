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
            var post = await _feedService.Create(id, feed.Status, feed.Files);
            return Ok(post);
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
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var list = await _feedService.GetAllFeed();
            if (list.Count <= 0)
                return NotFound();
            return Ok(list);
        }

        [Authorize]
        [HttpPost]
        public async  Task<IActionResult> GetAllPostByUserId([FromBody] int id)
        {
            var list = await _feedService.GetAllFeedByUserId(id);
            if (list.Count <= 0)
                return NotFound();
            return Ok(list);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SearchPost([FromBody] string keyWord)
        {
            if (keyWord == null)
            {
                return BadRequest();
            }

            var info = await _feedService.SearchFeed(keyWord);
            if (info == null)
            {
                return NotFound();
            }

            return Ok(info);
        }
    }
}
