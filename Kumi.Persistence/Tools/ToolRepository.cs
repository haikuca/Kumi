using System;
using Kumi.Domain.Tools.Interfaces;
using Kumi.Domain.Tools;
using Microsoft.EntityFrameworkCore;

namespace Kumi.Persistence.Tools;

public class ToolRepository(KumiDbContext kumiDbContext) : IToolRepository
{
    public async Task<List<Tool>> GetAll()
    {
        return await kumiDbContext.Set<Tool>().ToListAsync();
    }

    public async Task<Tool?> FindById(Guid toolId)
    {
        return await kumiDbContext.Set<Tool>().FindAsync(toolId);
    }

    public async Task<Tool?> FindByName(string toolName)
    {
        return await kumiDbContext.Set<Tool>()
            .FirstOrDefaultAsync(tool => tool.Name == toolName);
    }

    public async Task<Tool> AddAsync(Tool tool)
    {
        kumiDbContext.Set<Tool>().Add(tool);
        await kumiDbContext.SaveChangesAsync();
        return tool;
    }

    public async Task<Tool> UpdateAsync(Tool tool)
    {
        kumiDbContext.Update(tool);
        await kumiDbContext.SaveChangesAsync();
        return tool;
    }
    
    public async Task DeleteAsync(Tool tool)
    {
        kumiDbContext.Set<Tool>().Remove(tool);
        await kumiDbContext.SaveChangesAsync();
    }
}
