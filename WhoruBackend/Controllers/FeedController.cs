using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews.FeedModelViews;
using WhoruBackend.Services;
using WhoruBackend.Services.Implement;

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
            if (feed == null)
            {
                return BadRequest();
            }
            var post = await _feedService.Create(id, feed.Status);
            //if (feed.Files != null)
            //{
            //     await _feedService.UploadFeedImage(feed.Files);
            //}
            return Ok(post);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Delete success");
        }
    }
}
