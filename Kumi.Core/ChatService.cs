using System;
using System.Text.Json;
using Kumi.Core.Tools.Interfaces;
using Kumi.Core.Messages;
using Kumi.Domain.Messages;
using Kumi.LLM.Interfaces;

namespace Kumi.Core;

public class ChatService(ILanguageModel llm, IToolQueryActions toolQueryActions)
{
    private List<Message> Messages = new List<Message>();

    public async Task<Message> Chat(string message)
    {
        Message response = await llm.Chat(MessageHistory.Initialize(message, toolQueryActions).History);
        Console.WriteLine(response.Content);
        return response;
    }
}

