using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.ModelViews.UserModelViews;
using WhoruBackend.Services;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "admin")]
        //[AllowAnonymous]
        public ActionResult<UserDto> GetAll() {
            var list = _userService.GetAll();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<ResponseView> Create([FromBody] RegisterView user) {
            if (user == null)
            {
                return BadRequest("No user to add");
            }
            var register = _userService.Create(user);

            return Ok(register);
        }
    }
}
