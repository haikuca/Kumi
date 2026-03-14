using System;
using System.Text;
using System.Text.Json;
using Kumi.Domain;
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

        StringContent jsonContent = new(
            JsonSerializer.Serialize(new OllamaRequest
            {
                Model = Model,
                Messages = new[]
                {
                    new Message
                    {
                        Role = "user",
                        Content = message
                    }
                },
            }),
            Encoding.UTF8,
            "application/json"
        );

        HttpResponseMessage response = await httpClient.PostAsync("chat", jsonContent);
        var jsonResponse = await response.Content.ReadAsStringAsync();
        OllamaResponse t = JsonSerializer.Deserialize<OllamaResponse>(jsonResponse)!;
        return t!.Message!;
    }
}
