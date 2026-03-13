using System;

namespace Kumi.Domain.Tools;

public interface IToolRepository
{
    Tool? FindById(Guid toolId);
    List<Tool> GetAll();
    Tool Add(Tool tool);
    Tool Update(Tool tool);
    void Delete(Tool tool);
}
