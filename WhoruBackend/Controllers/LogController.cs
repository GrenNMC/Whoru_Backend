using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [Route("api/v1/[controller]s/[action]")]
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
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
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
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassModelView view)
        {
            if(view.pass == null || view.prePass == null)
            {
                return BadRequest();
            }
            var response = await _LogService.ChangePassword(view.pass, view.prePass);

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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RefreshToken()
        {
            var response = await _LogService.RefreshToken();
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

        [HttpPost]
        public async Task<IActionResult> SendCodeByMail([FromBody] int id)
        {
            var reponse = await _LogService.SendCodeByMail(id);
            return Ok(reponse);
        }

        //[HttpPost]
        //public async Task<IActionResult> SendCodeBySMS([FromBody] int id)
        //{
        //    var reponse = await _LogService.SendCodeBySMS(id);
        //    return Ok(reponse);
        //}

        [HttpPost]
        public async Task<IActionResult> VerifyPass([FromBody] VerifyPasswordModelView view)
        {
            if (view == null)
                return BadRequest();
            var response = await _LogService.VerifyPass(view.email, view.code);

            if (response.Message == MessageConstant.NOT_FOUND)
                return NotFound();
            else
            {
                if (response.Message == MessageConstant.VALIDATE_FAILED)
                    return BadRequest(response.Message);
                if (response.Message == MessageConstant.SYSTEM_ERROR)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult>VerifyAccount([FromBody]VerifyLogger logger)
        {
            if (logger == null)
                return BadRequest();
            var response = await _LogService.ActiveAccount(logger.IdUser.GetValueOrDefault(), logger.Code);
            if (response.Message == MessageConstant.NOT_FOUND)
                return NotFound();
            else
            {
                if (response.Message == MessageConstant.VALIDATE_FAILED)
                    return BadRequest(response.Message);
                if (response.Message == MessageConstant.SYSTEM_ERROR)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return Ok(response);
            }
        }
    }
}
