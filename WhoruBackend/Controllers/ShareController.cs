using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.Repositorys;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShareController: ControllerBase
    {
        private readonly IShareService _shareService;

        public ShareController(IShareService shareService)
        {
            _shareService = shareService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SharePost([FromBody] int idPost)
        {
            if (idPost < 0)
                return BadRequest();
            var str = await _shareService.SharePost(idPost);
            if(str.Message == MessageConstant.NOT_FOUND)
                return NotFound();
            if(str.Message == MessageConstant.SYSTEM_ERROR)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(str);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UnSharePost([FromBody] int idPost)
        {
            if (idPost < 0)
                return BadRequest();
            var str = await _shareService.UnSharePost(idPost);
            if (str.Message == MessageConstant.NOT_FOUND)
                return NotFound();
            if (str.Message == MessageConstant.SYSTEM_ERROR)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(str);
        }
    }
}
