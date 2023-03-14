using System.ComponentModel.DataAnnotations;

namespace Nostalgia.API.Models.Account
{
    public class UserProfileModel
    {
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public string? UserPwd { get; set; } = string.Empty;
        [Required]
        public string? UserMail { get; set;} = string.Empty;

    }
}
