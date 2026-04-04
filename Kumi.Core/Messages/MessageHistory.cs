using Kumi.Domain.Messages;

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

        public List<Message> AddAssistantMessage(string message)
        {
            this.History.Add(new Message{ Role = "assistant", Content = message });
            return this.History;
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
