using System;
using Kumi.API.Services;
using Kumi.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kumi.API.Controllers 
{
    public class ToolsController(ToolService toolService) : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ToolDto>> AddTool(ToolDto toolDto)
        {
            return HandleResult(await toolService.AddTool(toolDto));
        }
    }
}
