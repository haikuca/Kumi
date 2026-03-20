using System;
using Kumi.API.Assemblers;
using Kumi.API.DTOs;
using Kumi.Domain.Tools;
using Kumi.Core.Tools.Interfaces;

namespace Kumi.API.Services
{
    
    public class ToolService(IToolCommandActions toolCommandActions,
                             IToolQueryActions toolQueryActions,
                             ToolAssembler toolAssembler)
    {
        
        public async Task<Result<List<ToolDto>>> GetAllTools()
        {
            return Result<List<ToolDto>>.Success(
                toolAssembler.AssembleList(await toolQueryActions.ListAllTools())
            );
        }
        
        public async Task<Result<ToolDto>> AddTool(ToolDto tool) 
        {
            return Result<ToolDto>.Success(
                toolAssembler.Assemble(await toolCommandActions.AddTool(toolAssembler.Disassemble(tool)))
            );
        }

    }
}
