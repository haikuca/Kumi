using Kumi.Domain.Messages;

namespace Kumi.Core.Messages
{
    public class MessageHistory
    {
        public List<Message> History = new List<Message>();

        public MessageHistory(string tools)
        {
            this.History.Add(new Message{ Role = "system", Content = ReadPrompt() });
            this.History.Add(new Message{ Role = "assistant", Content = tools });
        }

        public List<Message> Append(Message message)
        {
            this.History.Add(message);
            return this.History;
        }

        public List<Message> AppendUserMessage(string message)
        {
            this.History.Add(new Message{ Role = "user", Content = message });
            return this.History;
        }
        
        public void PrintHistory() 
        {
            for(int i = 1; i < this.History.Count(); i++) 
            {
                Message message = this.History[i];
                Console.WriteLine($"role: {message.Role}\ncontent: {message.Content}\n");
            }
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
