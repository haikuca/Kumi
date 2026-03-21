using System;
using System.Text.Json;
using Kumi.Domain.Messages;
using Kumi.Core.Tools.Interfaces;

namespace Kumi.Core.Messages
{
    public class MessageHistory
    {
        public List<Message> History = new List<Message>();

        public MessageHistory(string tools, string prompt)
        {
            this.History.Add(new Message{ Role = "system", Content = ReadPrompt() });
            this.History.Add(new Message{ Role = "assistant", Content = tools });
            this.History.Add(new Message{ Role = "user", Content = prompt });
        }

        private string ReadPrompt()
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
}
