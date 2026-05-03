using Kumi.API.Application.Dtos;
using Kumi.Core.Chats;

namespace Kumi.API.Application.Services
{
    public class ChatService(Chat chat)
    {
        public async Task<Result<List<ChatMessageDto>>> Chat(ChatMessageDto prompt)
        {
            List<ChatMessageDto> messages = new();
            messages.Add(prompt);
            
            messages.Add(new ChatMessageDto
            {
                Type = "RESPONSE",
                Content = await chat.PromptAgent(prompt.Content)
            });

            return Result<List<ChatMessageDto>>.Success(messages);
        }
    }
}
