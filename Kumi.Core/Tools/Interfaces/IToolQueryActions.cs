using System;
using Kumi.Domain.Tools;

namespace Kumi.Core.Tools.Interfaces;

public interface IToolQueryActions
{
    public Task<List<Tool>> ListAllTools();
    public Task<Tool?> FindTool(Guid toolId);
    public Task<Tool?> FindToolByName(string name);
}
