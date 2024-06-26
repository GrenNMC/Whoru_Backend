﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WhoruBackend.Hubs;
using WhoruBackend.ModelViews.FeedModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [Route("api/v1/[controller]s/[action]")]
    [ApiController]
    public class LikeController: ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LikePost([FromBody] int idPost)
        {
            if(idPost < 0)
            {
                return BadRequest();
            }
            var response = await _likeService.LikeFeed(idPost);
            if (response.Message == MessageConstant.SYSTEM_ERROR)
                return StatusCode(StatusCodes.Status500InternalServerError);
            if (response.Message == MessageConstant.NOT_FOUND)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public  async Task<IActionResult> GetAllLikedUser([FromBody] GetAllReactModelView view)
        {
            if (view.IdPost < 0)
            {
                return BadRequest();
            }
            var list = await _likeService.GetAllUser(view.IdPost, view.Page);
            if (list == null)
                return NotFound();
            return Ok(list);
        }
    }
}
