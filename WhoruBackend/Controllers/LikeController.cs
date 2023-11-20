using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WhoruBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LikeController: ControllerBase
    {
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] int idPost)
        {
            var str = "You just liked The Post of id: "+ idPost;
            return Ok(str);
        }
    }
}
