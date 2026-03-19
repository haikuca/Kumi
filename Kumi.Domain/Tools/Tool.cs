using System;

namespace Kumi.Domain.Tools;

public class Tool
{
    public required Guid ToolId { get; set; }
    public required string Url { get; set; }
    public required Method Method { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Dictionary<string, Parameter> Parameters { get; set; }

    public static Tool NewInstance(string url, 
                                   Method method, 
                                   string name, 
                                   string description, 
                                   Dictionary<string, Parameter> parameters) => new()
    {
        ToolId = Guid.NewGuid(),
        Url = url,
        Method = method,
        Name = name,
        Description = description,
        Parameters = parameters,
    };

}
