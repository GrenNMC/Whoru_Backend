using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WhoruBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s/[action]")]
    public class ChatController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public IActionResult SendChat()
        {
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllChatUser()
        {
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public IActionResult GetAllChat()
        {
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteChat()
        {
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteAllChat()
        {
            return Ok();
        }
    }
}
