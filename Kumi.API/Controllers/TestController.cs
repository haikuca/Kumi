using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kumi.API.Controllers
{
    public class TestController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<string>> Test() =>
            HandleResult(Result<string>.Success("And we are off!"));
    }
}
