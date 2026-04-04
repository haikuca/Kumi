using System;
using Kumi.Core.Tools.Interfaces;
using Kumi.Domain.Tools.Interfaces;
using Kumi.Domain.Tools;

namespace Kumi.Core.Tools;

public class ToolActions(IToolRepository repository) : IToolQueryActions, IToolCommandActions
{
    public async Task<List<Tool>> ListAllTools()
    {
        return await repository.GetAll();
    }

    public async Task<Tool?> FindTool(Guid toolId) 
    {
        return await repository.FindById(toolId);
    }

    public async Task<Tool?> FindToolByName(string name)
    {
        return await repository.FindByName(name);
    }

    public async Task<Tool> AddTool(Tool tool)
    {
        return await repository.AddAsync(tool);
    }

    public async Task<Tool> UpdateTool(Tool tool)
    {
        return await repository.UpdateAsync(tool);
    }

    public async Task DeleteTool(Tool tool) 
    {      
        await repository.DeleteAsync(tool);
    }

}
