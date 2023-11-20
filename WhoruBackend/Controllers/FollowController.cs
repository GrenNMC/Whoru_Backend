using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WhoruBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FollowController: ControllerBase
    {
        [HttpPost]
        [Authorize]
        public IActionResult FollowUser([FromQuery] int id)
        {
            var str = "You just follow User have id: " + id;
            return Ok(str);
        }

        [HttpPost]
        [Authorize]
        public IActionResult UnFollowUser([FromQuery] int id)
        {
            var str = "You just unfollow User have id: " + id;
            return Ok(str);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllFollower()
        {
            var str = "List user";
            return Ok(str);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllFollowing()
        {
            var str = "List user";
            return Ok(str);
        }
    }
}
