using Kumi.Core;
using Kumi.Domain.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kumi.API.Controllers
{
    public class TestController(ToolsService toolsService) : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<Tool>> Test()
        {
            return HandleResult(Result<Tool>.Success(toolsService.Save(Tool.NewInstance("foo", Method.POST, "foo", "foo", new List<string>{"foo"}))));
        }
    }
}
