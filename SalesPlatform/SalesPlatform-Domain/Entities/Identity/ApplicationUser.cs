using Microsoft.AspNetCore.Identity;
using SalesPlatform_Domain.Entities.Chats;
using System.ComponentModel.DataAnnotations;

namespace SalesPlatform_Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? City { get; set; }

        public ICollection<UserChat> UserChats { get; set; }
        public ICollection<Message> SentMessages { get; set; }
    }
}
