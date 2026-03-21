using System;
using System.Text.Json;
using Kumi.Core.Tools.Interfaces;
using Kumi.Core.Messages;
using Kumi.Domain.Messages;
using Kumi.LLM.Interfaces;

namespace Kumi.Core;

public class ChatService(ILanguageModel llm, IToolQueryActions toolQueryActions)
{
    public async Task<Message> Chat(string message)
    {
        var tools = JsonSerializer.Serialize(await toolQueryActions.ListAllTools());
        Message response = await llm.Chat(new MessageHistory(tools, message).History);
        Console.WriteLine(response.Content);
        return response;
    }
}
