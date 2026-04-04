using System;
using System.Text;
using System.Text.Json;
using Kumi.Domain.Messages;
using Kumi.LLM.Interfaces;

namespace Kumi.LLM.Integrations.Ollama;

public class Ollama : ILanguageModel
{

    private string Model;

    public Ollama(string model)
    {
        this.Model = model;
    }

    public async Task<Message> Chat(List<Message> messages)
    {
        Console.WriteLine("Begin of chat");
        HttpClient httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:11434/api/")
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        var payload = JsonSerializer.Serialize(new OllamaRequest
        {
            Model = Model,
            Messages = messages.ToArray()
        }, options);
        StringContent jsonContent = new(payload, Encoding.UTF8, "application/json");


        HttpResponseMessage response = await httpClient.PostAsync("chat", jsonContent);
        var jsonResponse = await response.Content.ReadAsStringAsync();

        OllamaResponse t = JsonSerializer.Deserialize<OllamaResponse>(jsonResponse, options)!;
        Console.WriteLine(t!.Message!.Content);
        Console.WriteLine("End of chat");
        return t!.Message!;
    }
}
