using SalesPlatform_Domain.Entities.Identity;

namespace SalesPlatform_Domain.Entities.Chats
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Message> Messages { get; set; }
        public ICollection<UserChat> Participants { get; set; }
    }
}
