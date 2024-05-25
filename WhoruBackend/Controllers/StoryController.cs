using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WhoruBackend.ModelViews.StoryModelViews;
using WhoruBackend.Services;

namespace WhoruBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s/[action]")]
    public class StoryController : ControllerBase
    {
        private IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] NewStoryModelView file)
        {
            if(file  != null)
            {
                var response = await _storyService.Create(file.File);
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetStoryByUserId([FromBody] int page)
        {
            var response = await _storyService.GetAllByUserId(page);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteStory([FromBody] int StoryId)
        {
            var response = await _storyService.Delete(StoryId);
            return Ok(response);
        }
    }
}
