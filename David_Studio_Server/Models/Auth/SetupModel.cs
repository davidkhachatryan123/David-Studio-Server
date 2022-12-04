using System.ComponentModel.DataAnnotations;

namespace David_Studio_Server.Models.Auth
{
    public class SetupModel : UserModel
    {
        [Required]
        public string Email { get; set; } = null!;
    }
}
