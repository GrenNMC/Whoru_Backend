using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.ModelViews.UserModelViews;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetAll() {
            var list = await _userService.GetAll();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpPost]
        [AllowAnonymous]
        // Register
        public async Task<IActionResult> Create([FromBody] RegisterView user) {
            if (user == null)
            {
                return BadRequest(MessageConstant.NO_DATA_REQUEST);
            }
            var register = await _userService.Create(user);

            return Ok(register);
        }
    }
}
