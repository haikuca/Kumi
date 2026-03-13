using Kumi.Core;
using Kumi.Domain.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kumi.API.Controllers
{
    public class TestController(ChatService chatService) : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Test([FromQuery] string message)
        {
            return HandleResult(Result<string>.Success(await chatService.Chat(message)));
        }
    }
}
