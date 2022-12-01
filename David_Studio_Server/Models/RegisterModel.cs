using System.ComponentModel.DataAnnotations;

namespace David_Studio_Server.Models
{
    public class RegisterModel : UserModel
    {
        [Required]
        public string Email { get; set; }
    }
}
