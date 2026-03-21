using System;
using Kumi.Core.Tools.Interfaces;
using Kumi.Domain.Messages;
using Kumi.LLM.Interfaces;

namespace Kumi.Core;

public class ChatService(ILanguageModel llm, IToolQueryActions toolQueryActions)
{
    public async Task<Message> Chat(string message)
    {
        // ILanguageModel model = new Ollama();
        Message resposne = await llm.Chat(message);
        return resposne;
    }
}
