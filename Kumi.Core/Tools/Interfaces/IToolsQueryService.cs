using System;
using Kumi.Domain.Tools;

namespace Kumi.Core.Tools.Interfaces;

public interface IToolsQueryService
{
    public List<Tool> ListAllTools();
    public Tool? FindTool(Guid toolId);
}
