using System;
using System.Text.Json.Serialization;
using Kumi.Domain.Messages;

namespace Kumi.LLM.Integrations.Ollama;

public class OllamaResponse
{
    public Message? Message { get; set; }
}
