using System;
using Kumi.Domain.Tools;

namespace Kumi.Core.Tools.Interfaces;

public interface IToolsQueryService
{
    public Task<List<Tool>> ListAllTools();
    public Task<Tool?> FindTool(Guid toolId);
}
