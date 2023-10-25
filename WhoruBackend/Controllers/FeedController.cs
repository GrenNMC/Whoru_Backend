using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WhoruBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Post success");
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Delete success");
        }
    }
}
