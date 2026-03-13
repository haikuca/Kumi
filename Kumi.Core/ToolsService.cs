using System;
using Kumi.Domain.Tools;

namespace Kumi.Core;

public class ToolsService(IToolRepository toolRepository)
{
    public Tool Save(Tool tool)
    {
        return toolRepository.Add(tool);
    }
}
