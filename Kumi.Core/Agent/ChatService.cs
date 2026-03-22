using System;
using System.Text.Json;
using System.Xml.Linq;
using Kumi.Core.Tools.Interfaces;
using Kumi.Core.Messages;
using Kumi.Domain.Messages;
using Kumi.LLM.Interfaces;

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

    public void ParseResponse(string response)
    {
        var wrapped = $"<root>{response}</root>";
        XElement llmResponse = XElement.Parse(wrapped);

        var pause = llmResponse.Element("pause");

        if (pause != null)
        {
            MaybeCallTool(llmResponse);
        }
    }

    public void MaybeCallTool(XElement element)
    {
        var toolCall = element.Element("call_tool").Value;
        if (toolCall != null) 
        {
            CallTool(toolCall);
        }
    }

    public void CallTool(string rawToolCall)
    {
        Console.WriteLine(rawToolCall);
    }

}
