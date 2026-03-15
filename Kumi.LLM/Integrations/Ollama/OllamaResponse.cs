using System;
using System.Text.Json.Serialization;
using Kumi.Domain;

namespace Kumi.LLM.Integrations.Ollama;

public class OllamaResponse
{
    [JsonPropertyName("message")]
    public Message? Message { get; set; }
}
