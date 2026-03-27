using System;
using System.Text.Json;
using System.Xml.Linq;
using Kumi.Core.Tools.Interfaces;
using Kumi.Core.Messages;
using Kumi.Domain.Messages;
using Kumi.LLM.Interfaces;
using Kumi.Domain.Tools;

namespace Kumi.Core.Agent;

public class ChatService(ILanguageModel llm, IToolQueryActions toolQueryActions)
{
    public async Task<Message> Chat(string message)
    {
        var tools = JsonSerializer.Serialize(await toolQueryActions.ListAllTools());
        Message response = await llm.Chat(new MessageHistory(tools, message).History);
        ParseResponse(response.Content);
        return response;
    }

    public void ParseResponse(string llmResponse)
    {
        var wrapped = $"<root>{llmResponse}</root>";
        XElement element = XElement.Parse(wrapped);

        var pause = element.Element("pause");
        var response = element.Element("response")?.Value;

        if (pause != null)
        {
            MaybeCallTool(element);
        }
    }

    public void MaybeCallTool(XElement element)
    {
        string rawToolCall = element.Element("call_tool").Value;
        if (rawToolCall != null) 
        {
            CallTool(rawToolCall);
        }
    }

    public void CallTool(string rawToolCall)
    {
        Console.WriteLine(rawToolCall);
        CallTool callTool = JsonSerializer.Deserialize<CallTool>(
            rawToolCall,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        );
        Console.WriteLine(callTool.Name);
    }

}
