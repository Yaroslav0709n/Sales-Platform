using SalesPlatform_Domain.Entities.Identity;

namespace SalesPlatform_Domain.Entities.Chats
{
    public class UserChat
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
