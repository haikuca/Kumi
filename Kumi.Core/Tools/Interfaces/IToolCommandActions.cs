using System;
using Kumi.Domain.Tools;

namespace Kumi.Core.Tools.Interfaces;

public interface IToolCommandActions
{
    public Task<Tool> AddTool(Tool tool);
    public Task<Tool> UpdateTool(Tool tool);
    public Task DeleteTool(Tool tool);
}
