using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews.FeedModelViews;
using WhoruBackend.Utilities.Model;

namespace WhoruBackend.Controllers
{
    [Route("api/v1/[controller]s/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public IActionResult PredictFromResNetV250([FromForm] ImageModelView image)
        {
            var model = new Model();
            var result = model.ClassifyImage(image.File);
            return Ok(result.PredictedLabel);
        }
        
    }
}
