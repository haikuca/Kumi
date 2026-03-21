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

    public async Task<Message> Chat(string message)
    {
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
            Messages =
            [
                new Message
                {
                    Role = "user",
                    Content = message
                }
            ],
        }, options);
        StringContent jsonContent = new(payload, Encoding.UTF8, "application/json");

        Console.WriteLine(payload);

        HttpResponseMessage response = await httpClient.PostAsync("chat", jsonContent);
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);

        OllamaResponse t = JsonSerializer.Deserialize<OllamaResponse>(jsonResponse, options)!;
        return t!.Message!;
    }
}
