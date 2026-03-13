using System;

namespace Kumi.LLM.Interfaces;

public interface ILanguageModel
{
    public Task<string> Chat(string message);
}
