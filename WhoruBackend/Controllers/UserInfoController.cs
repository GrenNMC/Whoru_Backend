﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserInfoController: ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IUserService _userService;

        public UserInfoController(IUserInfoService userInfoService, IUserService userService)
        {
            _userInfoService = userInfoService;
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] RequestUserInfoView userInfoView)
        {
            if (userInfoView == null)
            {
                return BadRequest();
            }
            var request = await _userInfoService.Create(userInfoView);
            if(request.Message == MessageConstant.CREATE_SUCCESS)
            {
                return CreatedAtAction(nameof(GetInfoByName),userInfoView.FullName);
            }
            if(request.Message == MessageConstant.EXISTED)
            {
                return BadRequest();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateInfo([FromBody] RequestUserInfoView request)
        {
            if (request == null)
                return BadRequest();

            var response = await _userInfoService.Update(request);
            if (response.Message == MessageConstant.NOT_FOUND)
                return NotFound();
            else
            {
                if (response.Message == MessageConstant.SYSTEM_ERROR)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return Ok(response);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetInfoByName([FromQuery] string name)
        {
            if(name == null)
            {
                return BadRequest();
            }

            var info = await _userInfoService.GetUserInfoByName(name);    
            if(info == null)
            {
                return NotFound();
            }

            return Ok(info);
        }
    }
}
