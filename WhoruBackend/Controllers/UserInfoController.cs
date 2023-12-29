using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [Route("api/v1/[controller]s/[action]")]
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
                return CreatedAtAction(nameof(GetInfoById),userInfoView.FullName);
            }
            if(request.Message == MessageConstant.EXISTED)
            {
                return BadRequest();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateBackground( IFormFile file)
        {
            if (file == null)
                return BadRequest();

            var response = await _userInfoService.UpdateBackground(file);
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

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAvatar( IFormFile file)
        {
            if (file == null)
                return BadRequest();

            var response = await _userInfoService.UpdateAvatar(file);
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

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateInfo([FromBody]RequestUserInfoView request)
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SearchUser([FromBody] string name)
        {
            if(name == string.Empty)
            {
                return NotFound();
            }

            var info = await _userInfoService.GetUserInfoByName(name);    
            if(info == null)
            {
                return NotFound();
            }

            return Ok(info);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetInfoById([FromBody] int id)
        {
            if (id < 0 )
            {
                return BadRequest();
            }

            var info = await _userInfoService.GetUserInfoById(id);
            if (info == null)
            {
                return NotFound();
            }

            return Ok(info);
        }
    }
}
