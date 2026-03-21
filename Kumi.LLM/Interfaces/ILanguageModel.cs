using System;
using Kumi.Domain.Messages;

namespace Kumi.LLM.Interfaces;

public interface ILanguageModel
{
    public Task<Message> Chat(List<Message> messages);
}
