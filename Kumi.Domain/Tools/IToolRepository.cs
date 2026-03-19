using System;

namespace Kumi.Domain.Tools;

public interface IToolRepository
{
    Task<Tool?> FindById(Guid toolId);
    Task<List<Tool>> GetAll();
    Task<Tool> AddAsync(Tool tool);
    Task<Tool> UpdateAsync(Tool tool);
    Task DeleteAsync(Tool tool);
}
