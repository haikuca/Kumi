using System;
using Kumi.Domain;

namespace Kumi.LLM.Integrations.Ollama;

public class OllamaResponse
{
    public Message? Message { get; set; }
}
