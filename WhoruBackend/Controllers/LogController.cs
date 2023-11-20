using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _LogService;
        public LogController(ILogService logService)
        {
            _LogService = logService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromQuery] string email)
        {
            if (email == null)
            {
                return BadRequest();
            }
            var response = await _LogService.ResetPassword(email);
            if (response.Message == MessageConstant.SYSTEM_ERROR)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                if (response.Message == MessageConstant.NOT_FOUND)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromQuery] string newPassword)
        {
            if(newPassword == null)
            {
                return BadRequest();
            }
            var response = await _LogService.ChangePassword(newPassword);

            if (response.Message == MessageConstant.SYSTEM_ERROR)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                if (response.Message == MessageConstant.NOT_FOUND)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginView loginView) {
            var response = await _LogService.Login(loginView);
            if (response.Message == MessageConstant.NOT_FOUND)
            {
                return NotFound(response);
            }
            if (response.Message == MessageConstant.WRONG_PASSWORD)
            {
                return Unauthorized(response);
            }
            if (response.Message == MessageConstant.SYSTEM_ERROR)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SendCodeByMail()
        {
            var reponse = await _LogService.SendCodeByMail();
            return Ok(reponse);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SendCodeBySMS()
        {
            var reponse = await _LogService.SendCodeBySMS();
            return Ok(reponse);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult>VerifyAccount([FromQuery]string code)
        {
            var reponse = await _LogService.ActiveAccount(code);
            return Ok(reponse);
        }
    }
}
