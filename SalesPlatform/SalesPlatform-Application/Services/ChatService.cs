using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SalesPlatform_Application.Dtos.Chat;
using SalesPlatform_Application.Extensions;
using SalesPlatform_Application.IServices;
using SalesPlatform_Domain.Entities.Chats;
using SalesPlatform_Infrastructure.Repositories;

namespace SalesPlatform_Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IRepository<Chat> _chatRepository;
        private readonly IRepository<Message> _messageRepository;
        private readonly IRepository<UserChat> _userChatRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public ChatService(IRepository<Chat> chatRepository,
                           IRepository<Message> messageRepository,
                           IRepository<UserChat> userChatRepository,
                           IHttpContextAccessor contextAccessor,
                           IMapper mapper)
        {
            _chatRepository = chatRepository;
            _messageRepository = messageRepository;
            _userChatRepository = userChatRepository;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<ChatDto> GetChatAsync(int chatId)
        {
            var chat = await _chatRepository.GetByIdAsync(chatId);
                                           
            chat.ThrowIfNull(nameof(chat));

            return _mapper.Map<ChatDto>(chat);
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesAsync(int chatId)
        {
            var messages = await _messageRepository.Query()
                                                   .Where(mess => mess.ChatId == chatId)
                                                   .ToListAsync();

            messages.ThrowIfNull(nameof(messages));

            return _mapper.Map<IEnumerable<MessageDto>>(messages);
        }

        public async Task<IEnumerable<ChatDto>> GetCurrentUserChatsAsync()
        {
            var userId = _contextAccessor.HttpContext!.User.GetCurrentUserId().ToString();

            var chatIds = await _userChatRepository.Query()
                                             .Include(chats => chats.Chat)
                                             .Where(x => x.UserId == userId)
                                             .Select(id => id.ChatId)
                                             .ToListAsync();

            chatIds.ThrowIfNull(nameof(chatIds));

            var chats = await _chatRepository.Query()
                                            .Where(chat => chatIds.Contains(chat.Id))
                                            .ToListAsync();
            chats.ThrowIfNull(nameof(chats));

            return _mapper.Map<IEnumerable<ChatDto>>(chats);
        }

        public async Task CreateChatAsync(ChatDto chatDto, string secondUserId)
        {
            var userId = _contextAccessor.HttpContext!.User.GetCurrentUserId().ToString();

            var chat = _mapper.Map<Chat>(chatDto);

            await _chatRepository.AddAsync(chat);
            await _chatRepository.SaveChangesAsync();

            await AddUserToChat(userId, chat.Id);
            await AddUserToChat(secondUserId, chat.Id);
        }

        private async Task AddUserToChat(string userId, int chatId)
        {
            var userChat = new UserChat()
            {
                ChatId = chatId,
                UserId = userId,
            };

            await _userChatRepository.AddAsync(userChat);
            await _userChatRepository.SaveChangesAsync();
        }

        public async Task CreateMessageAsync(MessageDto messageDto, int chatId)
        {
            var userId = _contextAccessor.HttpContext!.User.GetCurrentUserId().ToString();

            var message = _mapper.Map<Message>(messageDto);
            message.SenderId = userId;
            message.ChatId = chatId;
            message.SendTime = DateTime.UtcNow;
            message.IsEdited = false;

            await _messageRepository.AddAsync(message);
            await _messageRepository.SaveChangesAsync();
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto, int messageId)
        {
            var messageExist = await _messageRepository.Query()
                                                        .FirstOrDefaultAsync(mess => mess.Id == messageId);

            messageExist.ThrowIfNull(nameof(messageExist));
            messageExist.Text = updateMessageDto.Text;
            messageExist.SendTime = DateTime.UtcNow;
            messageExist.IsEdited = true;

            var message = await _messageRepository.UpdateAsync(messageExist);
            await _messageRepository.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int messageId)
        {
            var message = await _messageRepository.GetByIdAsync(messageId);

            message.ThrowIfNull(nameof(message));

            _messageRepository.Delete(message);
            await _messageRepository.SaveChangesAsync();
        }
    }
}
