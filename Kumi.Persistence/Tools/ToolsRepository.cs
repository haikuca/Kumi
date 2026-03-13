using System;
using Kumi.Domain.Tools;

namespace Kumi.Persistence.Tools;

public class ToolsRepository(KumiDbContext kumiDbContext) : IToolRepository
{
    public Tool Add(Tool tool)
    {
        kumiDbContext.Add(tool);
        kumiDbContext.SaveChanges();
        return tool;
    }

    public void Delete(Tool tool)
    {
        throw new NotImplementedException();
    }

    public Tool? FindById(Guid toolId)
    {
        throw new NotImplementedException();
    }

    public List<Tool> GetAll()
    {
        throw new NotImplementedException();
    }

    public Tool Update(Tool tool)
    {
        throw new NotImplementedException();
    }
}
