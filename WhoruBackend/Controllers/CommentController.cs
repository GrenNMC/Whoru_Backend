using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoruBackend.Models;
using WhoruBackend.ModelViews.CommentModelViews;
using WhoruBackend.ModelViews.FeedModelViews;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s/[action]")]
    public class CommentController: ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetAllCommentByFeedId([FromBody] GetAllReactModelView view)
        {
            var list = await _commentService.GetAllCommentByFeedId(view.IdPost, view.Page);
            if(list.Count <= 0)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetCommentById([FromBody] int id)
        {
            var comment = await _commentService.FindCommentById(id);
            if(comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CommentModelView comment)
        {
            var response = await _commentService.Create(comment);
            if(response.Message == MessageConstant.NOT_FOUND)
                return NotFound();
            if(response.Message == MessageConstant.SYSTEM_ERROR)
                return StatusCode(StatusCodes.Status500InternalServerError);
            if (response.Message == MessageConstant.NO_DATA_REQUEST)
                return BadRequest();
            return CreatedAtAction(nameof(GetCommentById),response.Message);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateCommentModelView comment)
        {
            var response = await _commentService.Update(comment);
            if (response.Message == MessageConstant.NOT_FOUND)
                return NotFound();
            if (response.Message == MessageConstant.SYSTEM_ERROR)
                return StatusCode(StatusCodes.Status500InternalServerError);
            if (response.Message == MessageConstant.NO_DATA_REQUEST)
                return BadRequest();
            return Ok(response.Message);
        }

        [HttpDelete]
        [Authorize]
        public async  Task<IActionResult> Delete([FromBody] int id)
        {
            var response = await _commentService.Delete(id);
            if (response.Message == MessageConstant.NOT_FOUND)
                return NotFound();
            if (response.Message == MessageConstant.SYSTEM_ERROR)
                return StatusCode(StatusCodes.Status500InternalServerError);
            if (response.Message == MessageConstant.NO_DATA_REQUEST)
                return BadRequest();
            return Ok(response.Message);
        }
    }
}
