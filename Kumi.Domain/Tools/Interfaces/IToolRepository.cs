using System;

namespace Kumi.Domain.Tools.Interfaces;

public interface IToolRepository
{
    Task<Tool?> FindById(Guid toolId);
    Task<Tool?> FindByName(string toolName);
    Task<List<Tool>> GetAll();
    Task<Tool> AddAsync(Tool tool);
    Task<Tool> UpdateAsync(Tool tool);
    Task DeleteAsync(Tool tool);
}
