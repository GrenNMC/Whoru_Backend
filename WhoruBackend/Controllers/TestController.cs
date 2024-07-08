using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews.ChatModelViews;
using WhoruBackend.ModelViews.FeedModelViews;
using WhoruBackend.Utilities.Model;

namespace WhoruBackend.Controllers
{
    [Route("api/v1/[controller]s/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
    }
}
