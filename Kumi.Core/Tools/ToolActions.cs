using System;
using Kumi.Core.Tools.Interfaces;
using Kumi.Domain.Tools;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Kumi.Core.Tools;

public class ToolActions(IToolRepository repository) : IToolQueryActions, IToolCommandActions
{
    public async Task<Tool> AddTool(Tool tool) =>
        await repository.AddAsync(tool);

    public async Task DeleteTool(Tool tool) =>
        await repository.DeleteAsync(tool);

    public async Task<Tool?> FindTool(Guid toolId) =>
        await repository.FindById(toolId);

    public async Task<List<Tool>> ListAllTools() =>
        await repository.GetAll();

    public async Task<Tool> UpdateTool(Tool tool) =>
        await repository.UpdateAsync(tool);
}
