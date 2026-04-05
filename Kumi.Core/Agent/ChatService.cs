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
    private MessageHistory messageHistory;

    public async Task<Message> Chat(string message)
    {
        
        var tools = JsonSerializer.Serialize(await toolQueryActions.ListAllTools());
        this.messageHistory = new MessageHistory(tools, message);
        Message response = await llm.Chat(this.messageHistory.History);
        this.messageHistory.Append(response);
        return await ParseMessage(response.Content); 
    }

    public async Task<Message> ParseMessage(string llmResponse)
    {
        this.messageHistory.PrintHistory();
        var wrapped = $"<root>{llmResponse}</root>";
        XElement element = XElement.Parse(wrapped);

        var pause = element.Element("pause");
        var response = element.Element("response")?.Value;

        if (pause != null)
        {
            string? toolResponse = await MaybeCallTool(element);
            this.messageHistory.AppendUserMessage(toolResponse); 
            Message newChatResponse = await llm.Chat(this.messageHistory.History);
            this.messageHistory.Append(newChatResponse);
            return await ParseMessage(newChatResponse.Content); 
        }
        if (response != null) 
        {
            return new Message
            {
                Role = "assistant",
                Content = element.Element("response").Value
            };
        }

        return null;
    }

    public async Task<string?> MaybeCallTool(XElement element)
    {
        string rawToolCall = element.Element("call_tool").Value;
        if (rawToolCall != null) 
        {
            return await CallTool(rawToolCall);
        }
        return null;
    }

    public async Task<string> CallTool(string rawToolCall)
    {
        CallTool callTool = JsonSerializer.Deserialize<CallTool>(
            rawToolCall,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        );
        string parameters = JsonSerializer.Serialize(callTool.Parameters); 
        string? response = await ToolInvoker.Invoke(await toolQueryActions.FindToolByName(callTool.Name), new StringContent(parameters, Encoding.UTF8, "application/json"));
        return response;
    }
}
