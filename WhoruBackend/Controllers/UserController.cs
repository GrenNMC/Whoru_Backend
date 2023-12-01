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
        //[Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        [Authorize]
        public async Task<IActionResult> GetAll() {
            var list = await _userService.GetAll();
            if (list.Count <= 0)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetUserByName([FromBody] string name)
        {
            if(name == null)
            {
                return BadRequest();
            }
            var user = await _userService.GetUserByName(name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetUserById([FromBody] int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
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

            if(register.Message == MessageConstant.USERNAME_EXISTED)
            {
                return BadRequest(register.Message);
            }
            return CreatedAtAction(nameof(GetUserByName),user.UserName);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] UpdateUserModelView updatedUser)
        {    
            return Ok(updatedUser);
        }
    }
}
