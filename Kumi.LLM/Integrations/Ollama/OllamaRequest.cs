using System;
using Kumi.Domain.Messages;

namespace Kumi.LLM.Integrations.Ollama;

public class OllamaRequest
{
    public required string Model { get; set; }
    public required Message[] Messages { get; set; }
    public bool Think { get; set;} = false;
    public bool Stream { get; set; } = false;
}
