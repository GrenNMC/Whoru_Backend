using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews.UserModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            if(request > 0)
            {
                return CreatedAtAction(nameof(GetInfoById),request);
            }
            if(request == -1)
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
        public async Task<IActionResult> SearchUser([FromBody] SearchInfoModelView view)
        {
            var info = await _userInfoService.GetUserInfoByName(view.keyword,view.page);    
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostEmbeddingForUser([FromBody] EmbeddingModelView view)
        {
            if (view != null)
            {
                var response = await _userInfoService.UpdateEmbededNumber(view);
                return CreatedAtAction(nameof(GetListEmbedding), response);
            }
            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListEmbedding()
        {
            var response = await _userInfoService.GetEmbeddedNumber();
            if(response != null && response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostListSuggestions([FromBody] FriendshipSuggestionsModelView view)
        {
            var response = await _userInfoService.PostSuggestionFriendList(view.listIdUser);
            if (response.Message == MessageConstant.CREATE_SUCCESS)
            {
                return CreatedAtAction(nameof(PostListSuggestions), response); 
            }
            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListSuggestions()
        {
            var response = await _userInfoService.GetSuggestionFriendList();
            if (response != null && response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound();
        }
    }
}
