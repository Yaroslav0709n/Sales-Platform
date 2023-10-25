using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesPlatform_Application.Dtos.Chat;
using SalesPlatform_Application.IServices;

namespace SalesPlatform_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> GetCurrentUserChats()
        {
            var chats = await _chatService.GetCurrentUserChatsAsync();

            return Ok(chats);
        }

        [HttpGet("chatId"), Authorize]
        public async Task<ActionResult> GetChatById(int chatId)
        {
            var chat = await _chatService.GetChatAsync(chatId);

            return Ok(chat);
        }

        [HttpGet("messages"), Authorize]
        public async Task<ActionResult> GetMessages(int chatId)
        {
            var message = await _chatService.GetMessagesAsync(chatId);

            return Ok(message);
        }


        [HttpPost, Authorize]
        public async Task<ActionResult> CreateChat(ChatDto chatDto, string secondUserId)
        {
            await _chatService.CreateChatAsync(chatDto, secondUserId);

            return Ok(true);
        }

        [HttpPost("chatId"), Authorize]
        public async Task<ActionResult> CreateMessage(MessageDto messageDto, int chatId)
        {
            await _chatService.CreateMessageAsync(messageDto, chatId);

            return Ok(true);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult> UpdateMessage(UpdateMessageDto messageDto, int messageId)
        {
            await _chatService.UpdateMessageAsync(messageDto, messageId);

            return Ok(true);
        }

        [HttpDelete, Authorize]
        public async Task<ActionResult> DeleteMessage(int messageId)
        {
            await _chatService.DeleteMessageAsync(messageId);

            return Ok(true);
        }
    }
}
