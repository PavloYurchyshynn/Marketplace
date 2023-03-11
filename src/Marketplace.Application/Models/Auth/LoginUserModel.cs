using System.ComponentModel.DataAnnotations;

namespace Marketplace.Application.Models.Auth
{
    public class LoginUserModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }

    public class LoginResponseModel
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Token { get; set; }
    }
}
