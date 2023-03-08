using System.ComponentModel.DataAnnotations;

namespace Marketplace.Application.Models.User
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
