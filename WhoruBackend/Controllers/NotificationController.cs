using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.Services;

namespace WhoruBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s/[action]")]
    public class NotificationController: ControllerBase
    {
        private readonly INotificationService _NotiService;

        public NotificationController(INotificationService notiService)
        {
            _NotiService = notiService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllNotification() 
        {
            var list = await _NotiService.GetAllNotification();
            if(list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }
    }
}
