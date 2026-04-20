using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kumi.API.DTOs;
using Kumi.API.Services;

namespace Kumi.API.Controllers
{
    public class ChatController(ChatService chatService) : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<List<ChatMessageDto>>> Chat(ChatMessageDto chatMessage)
        {
            return HandleResult(await chatService.Chat(chatMessage));
        }
    }
}
