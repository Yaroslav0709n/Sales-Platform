using AutoMapper;
using SalesPlatform_Application.Dtos.Chat;
using SalesPlatform_Domain.Entities.Chats;

namespace SalesPlatform_Application.Mappings
{
    public class ChatMapper:Profile
    {
        public ChatMapper()
        {
            CreateMap<ChatDto, Chat>();
            CreateMap<Chat, ChatDto>();

            CreateMap<MessageDto, Message>();
            CreateMap<Message, MessageDto>();
        }
    }
}
