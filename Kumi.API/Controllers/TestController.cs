using Kumi.Core;
using Kumi.Domain;
using Kumi.Domain.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kumi.API.Controllers
{
    public class TestController(ChatService chatService) : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<Message>> Test([FromQuery] string message)
        {
            return HandleResult(Result<Message>.Success(await chatService.Chat(message)));
        }
    }
}
