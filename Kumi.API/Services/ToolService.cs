using System;
using Kumi.API.Assemblers;
using Kumi.API.DTOs;
using Kumi.Domain.Tools;
using Kumi.Core.Tools.Interfaces;

namespace Kumi.API.Services
{
    
    public class ToolService(IToolsCommandService toolsCommandService, ToolAssembler toolAssembler)
    {

        public async Task<Result<ToolDto>> AddTool(ToolDto tool) 
        {
            return Result<ToolDto>.Success(
                toolAssembler.Assemble(
                    await toolsCommandService.AddTool(toolAssembler.Disassemble(tool))
                )
            );
        }

    }
}
