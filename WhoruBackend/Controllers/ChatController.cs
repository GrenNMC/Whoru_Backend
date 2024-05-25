﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WhoruBackend.ModelViews.ChatModelViews;
using WhoruBackend.Services;
using WhoruBackend.Services.Implement;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s/[action]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetAllChatUser([FromBody] int page)
        {
            var list = await _chatService.GetAllUser(page);
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetAllChat([FromBody] GetAllChatModelView view)
        {
            var list = await _chatService.GetAllChat(view.IdUser, view.Page);
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteChat([FromBody] int idChat)
        {
            var response = await _chatService.DeleteChat(idChat);
            if (response.Message == MessageConstant.NOT_FOUND)
                return NotFound();
            if (response.Message == MessageConstant.SYSTEM_ERROR)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(response.Message);
        }
    }
}
