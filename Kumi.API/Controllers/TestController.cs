using Kumi.Core.Agents;
using Kumi.Domain.Messages;
using Kumi.Core.Chats;
using Kumi.Domain.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kumi.API.Controllers
{
    public class TestController(Chat chatService) : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<Message>> Test([FromQuery] string message)
        {
            return HandleResult(Result<Message>.Success(await chatService.PromptAgent(message)));
        }
    }
}
