﻿using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews;
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
    }
}