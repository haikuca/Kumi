using System;
using System.Text;
using System.Text.Json;
using Kumi.LLM.Interfaces;

namespace Kumi.LLM.Integrations;

public class Ollama : ILanguageModel
{
    public async Task<string> Chat(string message)
    {
        HttpClient httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:11434/api/")
        };

        StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                model = "qwen3.5",
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = message
                    }
                },
                think = false,
                stream = false
            }),
            Encoding.UTF8,
            "application/json"
        );

        HttpResponseMessage response = await httpClient.PostAsync("chat", jsonContent);
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return jsonResponse;
    }
}
