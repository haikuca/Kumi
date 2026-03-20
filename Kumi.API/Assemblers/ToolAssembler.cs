using System;
using Kumi.API.DTOs;
using Kumi.Domain.Tools;

namespace Kumi.API.Assemblers;

public class ToolAssembler
{
  
    public ToolDto Assemble(Tool entity) 
    {
        return new ToolDto 
        {
            ToolId = entity.ToolId;
            Url = entity.Url;
            Method = entity.Method;
            Name = entity.Name;
            Description = entity.Description;
            Parameters = entity.Parameters;
        }
    }

    public Tool Disassemble(ToolDto dto)
    {
        return new Tool
        {
           Url = dto.Url;
           Method = dto.Method;
           Name = dto.Name;
           Description = dto.Description;
           Parameters = dto.Parameters;
        }
    }

}
