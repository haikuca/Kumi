using System;
using Kumi.Core.Tools.Interfaces;
using Kumi.Domain.Tools;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Kumi.Core.Tools;

public class ToolsService(IToolRepository repository) : IToolsQueryService, IToolsCommandService
{
    public Tool AddTool(Tool tool) =>
        repository.Add(tool);

    public void DeleteTool(Tool tool) =>
        repository.Delete(tool);

    public Tool? FindTool(Guid toolId) =>
        repository.FindById(toolId);

    public List<Tool> ListAllTools() =>
        repository.GetAll();

    public Tool UpdateTool(Tool tool) =>
        repository.Update(tool);
}
