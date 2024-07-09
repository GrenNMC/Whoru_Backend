using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews.FeedModelViews;
using WhoruBackend.Services;
using WhoruBackend.Services.Implement;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [Route("api/v1/[controller]s/[action]")]
    [ApiController]
    public class SavedFeedController : ControllerBase
    {
        private readonly ISavedPostService _savedPostService;

        public SavedFeedController(ISavedPostService savedPostService)
        {
            _savedPostService = savedPostService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SavePost([FromBody] int idPost)
        {
            if (idPost < 0)
                return BadRequest();
            var str = await _savedPostService.SavedPost(idPost);
            if (str.Message == MessageConstant.SYSTEM_ERROR)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(str);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UnSavePost([FromBody] int idPost)
        {
            if (idPost < 0)
                return BadRequest();
            var str = await _savedPostService.UnSavedPost(idPost);
            if (str.Message == MessageConstant.SYSTEM_ERROR)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(str);
        }
    }
}
