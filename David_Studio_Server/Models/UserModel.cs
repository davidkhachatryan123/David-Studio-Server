using System.ComponentModel.DataAnnotations;

namespace David_Studio_Server.Models
{
    public class UserModel
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
