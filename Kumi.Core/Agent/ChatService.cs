using System;
using System.Net.Http;
using System.Text;
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
        await ParseResponse(response.Content);
        return response;
    }

    public async Task ParseResponse(string llmResponse)
    {
        Console.WriteLine(llmResponse);
        var wrapped = $"<root>{llmResponse}</root>";
        XElement element = XElement.Parse(wrapped);

        var pause = element.Element("pause");
        var response = element.Element("response")?.Value;

        if (pause != null)
        {
            await MaybeCallTool(element);
        }
    }

    public async Task MaybeCallTool(XElement element)
    {
        string rawToolCall = element.Element("call_tool").Value;
        if (rawToolCall != null) 
        {
            CallTool(rawToolCall);
        }
    }

    public async Task CallTool(string rawToolCall)
    {
        Console.WriteLine(rawToolCall);
        CallTool callTool = JsonSerializer.Deserialize<CallTool>(
            rawToolCall,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        );
        string parameters = JsonSerializer.Serialize(callTool.Parameters); 
        string? response = await ToolInvoker.Invoke(await toolQueryActions.FindToolByName(callTool.Name), new StringContent(parameters, Encoding.UTF8, "application/json"));
        Console.WriteLine(response);
    }
}
