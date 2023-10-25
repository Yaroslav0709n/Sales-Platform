using SalesPlatform_Application.Dtos.Chat;
using SalesPlatform_Domain.Entities.Chats;

namespace SalesPlatform_Application.IServices
{
    public interface IChatService
    {
        Task<IEnumerable<ChatDto>> GetCurrentUserChatsAsync();
        Task<ChatDto> GetChatAsync(int chatId);
        Task<IEnumerable<MessageDto>> GetMessagesAsync(int chatId);
        Task CreateChatAsync(ChatDto chatDto, string secondUserId);
        Task CreateMessageAsync(MessageDto messageDto, int chatId);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto, int messageId);
        Task DeleteMessageAsync(int messageId);
    }
}
