using System;
using Kumi.Domain;
using Kumi.LLM.Interfaces;

namespace Kumi.Core;

public class ChatService(ILanguageModel llm)
{
    public async Task<Message> Chat(string message)
    {
        // ILanguageModel model = new Ollama();
        Message resposne = await llm.Chat(message);
        return resposne;
    }
}
