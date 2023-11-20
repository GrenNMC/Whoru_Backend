using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WhoruBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShareController: ControllerBase
    {
        [HttpPost]
        [Authorize]
        public IActionResult SharePost([FromQuery] int idPost)
        {
            var str = "You just shared the Post of id: "+ idPost;
            return Ok(str);
        }

        [HttpPost]
        [Authorize]
        public IActionResult UnSharePost([FromQuery] int idPost)
        {
            var str = "You just unshared the Post of id: " + idPost;
            return Ok(str);
        }
    }
}
