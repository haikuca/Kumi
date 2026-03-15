using System;
using System.Text.Json.Serialization;

namespace Kumi.Domain;

public class Message
{
    [JsonPropertyName("role")]
    public string? Role { get; set; }
    [JsonPropertyName("content")]
    public string? Content { get; set; }
}
