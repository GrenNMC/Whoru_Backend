using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.Models.dto;
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
        public ActionResult<UserDto> GetAll(){
            var list = _userService.GetAll();
            return Ok(list);
        }

        [HttpPost]
        public ActionResult<UserDto> Create([FromBody] UserDto userDto) {
            if (userDto == null)
            {
                return BadRequest(userDto);
            }
            var user = _userService.Create(userDto);


            return Ok(user);
        }
    }
}
