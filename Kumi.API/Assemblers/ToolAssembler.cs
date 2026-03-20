using System;
using Kumi.API.DTOs;
using Kumi.Domain.Tools;
using Kumi.Domain;

namespace Kumi.API.Assemblers;

public class ToolAssembler(ParameterAssembler parameterAssembler)
{
  
    public ToolDto Assemble(Tool entity) 
    {
        return new ToolDto 
        {
            ToolId = entity.ToolId,
            Url = entity.Url,
            Method = entity.Method.ToString(),
            Name = entity.Name,
            Description = entity.Description,
            Parameters = entity.Parameters.ToDictionary(
                x => x.Key,
                x => parameterAssembler.Assemble(x.Value)
            )
        };
    }

    public List<ToolDto> AssembleList(List<Tool> entities) 
    {
        return entities
            .Select(entity => Assemble(entity))
            .ToList();
    }

    public Tool Disassemble(ToolDto dto)
    {
        return Tool.NewInstance(
            dto.Url,
            Enum.Parse<Method>(dto.Method),
            dto.Name,
            dto.Description,
            dto.Parameters.ToDictionary(
                x => x.Key,
                x => parameterAssembler.Disassemble(x.Value)
            )
        );
    }


}
