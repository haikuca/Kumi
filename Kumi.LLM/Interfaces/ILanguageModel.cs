using System;
using Kumi.Domain;

namespace Kumi.LLM.Interfaces;

public interface ILanguageModel
{
    public Task<Message> Chat(string message);
}
