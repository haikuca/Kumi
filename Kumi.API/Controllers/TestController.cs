using Kumi.Core.Agent;
using Kumi.Domain.Messages;
using Kumi.Domain.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kumi.API.Controllers
{
    public class TestController(ChatService chatService) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<string>> T()
        {
            return HandleResult(Result<string>.Success("Running."));
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Test([FromQuery] string message)
        {
            return HandleResult(Result<Message>.Success(await chatService.Chat(message)));
        }
    }
}
