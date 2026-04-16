using System.Text;
using System.Text.Json;
using Kumi.Core.Tools.Interfaces;
using Kumi.Core.Messages;
using Kumi.Core.Agents;
using Kumi.Domain.Messages;
using Kumi.LLM.Interfaces;

namespace Kumi.Core.Chats;

public class Chat(IToolQueryActions toolQueryActions, ILanguageModel lm)
{
    private MessageHistory messageHistory;

    public async Task<Message> PromptAgent(string message)
    {
        string tools = JsonSerializer.Serialize(await toolQueryActions.ListAllTools());
        this.messageHistory = new MessageHistory(tools);
        Agent agent = new Agent(toolQueryActions, lm, messageHistory);
        return await agent.Prompt(message);
    }
}
