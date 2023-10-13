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
        public async Task<IActionResult> Login([FromBody] LoginView loginView) {
            var response = await _LogService.Login(loginView);
            if (response.Message == MessageConstant.NOT_FOUND)
            {
                Log.Information(response.Message);
                return NotFound(response);
            }
            if (response.Message == MessageConstant.WRONG_PASSWORD)
            {
                Log.Information(response.Message);
                return Unauthorized(response);
            }
            if (response.Message == MessageConstant.SYSTEM_ERROR)
            {
                Log.Information(response.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Log.Information(response.Message);
            return Ok(response);
        }
    }
}
