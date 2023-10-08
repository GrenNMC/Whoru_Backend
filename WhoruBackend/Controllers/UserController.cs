using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.Models.dto;
using WhoruBackend.ModelViews;
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
        [Authorize]
        public ActionResult<UserDto> GetAll() {
            var list = _userService.GetAll();
            return Ok(list);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<ResponseView> Create([FromBody] RegisterView user) {
            if (user == null)
            {
                return BadRequest("Không có");
            }
            var register = _userService.Create(user);

            return Ok(register.Message);
        }
    }
}
