using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WhoruBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommentController: ControllerBase
    {
        [HttpPost]
        [Authorize]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
