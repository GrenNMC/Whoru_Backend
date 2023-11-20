using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews.FeedModelViews;
using WhoruBackend.Services;
using WhoruBackend.Services.Implement;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> Delete([FromQuery]int id)
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
    }
}
