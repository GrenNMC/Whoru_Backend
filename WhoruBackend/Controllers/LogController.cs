using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews;
using WhoruBackend.Services;

namespace WhoruBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogController
    {
        private readonly ILogService _LogService;

        public LogController(ILogService logService)
        {
            _LogService = logService;
        }

        [HttpPost]
        
        public async Task<ResponseLoginView> Login([FromBody] LoginView loginView) {
            return await _LogService.Login(loginView);
        }
    }
}
