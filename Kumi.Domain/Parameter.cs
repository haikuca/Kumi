using System;

namespace Kumi.Domain;

public class Parameter
{
    public required string Type { get; set; }
    public required string Description { get; set; }
    public required bool Required { get; set; } 
}
