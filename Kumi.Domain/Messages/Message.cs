using System;
using System.Text.Json.Serialization;

namespace Kumi.Domain.Messages;

public class Message
{
    public string Role { get; set; }
    public string Content { get; set; }
}
