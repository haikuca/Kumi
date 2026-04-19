using System;
using Kumi.API.DTOs;
using Kumi.Domain.Tools;

namespace Kumi.API.Assemblers;

public class ParameterAssembler
{
    public ParameterDto Assemble(Parameter entity)
    {
       return new ParameterDto
       {
            Type = entity.Type,
            Description = entity.Description,
            Required = entity.Required
       };
    }

    public Parameter Disassemble(ParameterDto dto)
    {
        return new Parameter
        {
            Type = dto.Type,
            Description = dto.Description,
            Required = dto.Required
        };
    }

}
