using System.ComponentModel.DataAnnotations;

namespace David_Studio_Server.ViewModels.Auth
{
    public class SetupModel : UserModel
    {
        [Required]
        public string Email { get; set; } = null!;
    }
}
