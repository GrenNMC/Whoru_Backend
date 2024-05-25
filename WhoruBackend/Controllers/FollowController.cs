using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WhoruBackend.ModelViews.FollowModelViews;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [Route("api/v1/[controller]s/[action]")]
    [ApiController]
    public class FollowController: ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> FollowUser([FromBody] int id)
        {
            var response = await _followService.FollowUser(id);
            if(response.Message == MessageConstant.NOT_FOUND)
            {
                return NotFound();
            }
            if(response.Message == MessageConstant.SYSTEM_ERROR)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UnFollowUser([FromBody] int id)
        {
            var response = await _followService.UnFollowUser(id);
            if (response.Message == MessageConstant.NOT_FOUND)
            {
                return NotFound();
            }
            if (response.Message == MessageConstant.SYSTEM_ERROR)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetAllFollower([FromBody] int page)
        {
            var list = await _followService.GetAllFollower(page);
            if (list.Count <= 0)
                return NotFound();
            return Ok(list);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetAllFollowing([FromBody] int page)
        {
            var list = await _followService.GetAllFollowing(page);
            if (list.Count <= 0)
                return NotFound();
            return Ok(list);
        }
    }
}
