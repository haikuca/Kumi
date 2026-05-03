using System;

namespace Kumi.API.Application.Dtos;

public class ParameterDto
{
    public required string Type { get; set; }
    public required string Description { get; set; }
    public required bool Required { get; set; }
}

