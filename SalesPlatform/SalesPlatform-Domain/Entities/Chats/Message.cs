using SalesPlatform_Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace SalesPlatform_Domain.Entities.Chats
{
    public class Message
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int ChatId { get; set; }
        public Chat Chat { get; set; }

        [Required]
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        [Required]
        public DateTime SendTime { get; set; }
        public bool? IsEdited { get; set; }
    }
}
