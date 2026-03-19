using System;
using Kumi.Domain.Tools;

namespace Kumi.Core.Tools.Interfaces;

public interface IToolsCommandService
{
    public Tool AddTool(Tool tool);
    public Tool UpdateTool(Tool tool);
    public void DeleteTool(Tool tool);
}
