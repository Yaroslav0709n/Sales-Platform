using System.ComponentModel.DataAnnotations;

namespace SalesPlatform_Application.Dtos.Auth
{
    public class LoginDto
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
