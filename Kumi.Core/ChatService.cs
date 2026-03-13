using System;
using Kumi.LLM.Integrations;
using Kumi.LLM.Interfaces;

namespace Kumi.Core;

public class ChatService
{
    public async Task<string> Chat(string message)
    {
        ILanguageModel model = new Ollama();
        string resposne = await model.Chat(message);
        return resposne;
    }
}
