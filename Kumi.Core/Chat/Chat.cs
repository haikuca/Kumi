using System.Text;
using System.Text.Json;
using Kumi.Core.Tools.Interfaces;
using Kumi.Core.Messages;

namespace Kumi.Core.Chat;

public class Chat(IToolQueryActions toolQueryActions)
{
    private MessageHistory messageHistory;

    public async Task<Message> InitializeAgent(string message)
    {
        string tools = JsonSerializer.Serialize(await toolQueryActions.ListAllTools());
        this.messageHistory = new MessageHistory(tools, message);
    }
}
