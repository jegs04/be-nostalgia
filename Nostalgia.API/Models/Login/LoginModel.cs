using System.ComponentModel.DataAnnotations;

namespace Nostalgia.API.Models.Login
{
    public class LoginModel
    {
        [Required]
        public string userName { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
