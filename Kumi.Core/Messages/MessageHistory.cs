using System;
using System.Text.Json;
using Kumi.Domain.Messages;
using Kumi.Core.Tools.Interfaces;

namespace Kumi.Core.Messages
{
    public class MessageHistory(IToolQueryActions toolQueryActions)
    {
        public List<Message> History = new List<Message>();
        private readonly IToolQueryActions _toolQueryActions = toolQueryActions;

        public static Task<MessageHistory> Initialize(string prompt, IToolQueryActions toolQueryActions2)
        {
            MessageHistory messageHistory = new MessageHistory(toolQueryActions2);
            return messageHistory.InitializeAsync(prompt);
        }

        private async Task<MessageHistory> InitializeAsync(string prompt)
        {
            this.History.Add(new Message{ Role = "system", Content = ReadPrompt() });
            this.History.Add(new Message{ Role = "assistant", Content = await QueryTools() });
            this.History.Add(new Message{ Role = "user", Content = prompt });
            return this;
        }

        private string ReadPrompt()
        {
            try
            {
                using StreamReader reader = new("../../prompt.txt");
                string text = reader.ReadToEnd();
                return text;
            }
            catch (IOException e)
            {
                throw new IOException(e.Message);
            }
        }

        private async Task<string> QueryTools()
        {
            return JsonSerializer.Serialize(await _toolQueryActions.ListAllTools());
        }

    }
}
