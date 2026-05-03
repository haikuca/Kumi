using System;
using Kumi.API.Application.Mappings;
using Kumi.API.Application.Dtos;
using Kumi.Domain.Tools;
using Kumi.Core.Tools.Interfaces;

namespace Kumi.API.Application.Services
{
    
    public class ToolService(IToolCommandActions toolCommandActions,
                             IToolQueryActions toolQueryActions,
                             ToolMapper toolMapper)
    {
        
        public async Task<Result<List<ToolDto>>> GetAllTools()
        {
            return Result<List<ToolDto>>.Success(
                toolMapper.ToDtoList(await toolQueryActions.ListAllTools())
            );
        }
        
        public async Task<Result<ToolDto>> AddTool(ToolDto tool) 
        {
            return Result<ToolDto>.Success(
                toolMapper.ToDto(await toolCommandActions.AddTool(toolMapper.ToEntity(tool)))
            );
        }

        public async Task<Result<Unit>> DeleteTool(string toolId)
        {
            Tool? tool = await toolQueryActions.FindTool(Guid.Parse(toolId));
            await toolCommandActions.DeleteTool(tool!);
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
