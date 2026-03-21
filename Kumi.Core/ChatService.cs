using System;
using System.Text.Json;
using Kumi.Core.Tools.Interfaces;
using Kumi.Domain.Messages;
using Kumi.LLM.Interfaces;
 

namespace Kumi.Core;

public class ChatService(ILanguageModel llm, IToolQueryActions toolQueryActions)
{
    private List<Message> Messages = new List<Message>();

    public async Task<Message> Chat(string message)
    {
        var payload = JsonSerializer.Serialize(await toolQueryActions.ListAllTools());

        Messages.Add(new Message
        {
            Role = "system",
            Content = ReadPrompt()
        });

        Messages.Add(new Message
        {
            Role = "assistant",
            Content = payload
        });

        Messages.Add(new Message
        {
            Role = "user",
            Content = message
        });
      
        Message response = await llm.Chat(Messages);
        Console.WriteLine(response.Content);
        return response;

        /*
        Message resposne = await llm.Chat(message);
        return resposne;
        */
    }

    public string ReadPrompt()
    {
        try 
        {
            using StreamReader reader = new("../prompt.txt");
            string text = reader.ReadToEnd();
            return text;
        }
        catch (IOException e)
        {
            throw new IOException(e.Message);

        }
    }
}


