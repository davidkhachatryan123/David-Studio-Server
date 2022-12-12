using System.ComponentModel.DataAnnotations;

namespace David_Studio_Server.ViewModels.Auth
{
    public class TwoFactorModel
    {
        [Required]
        public string TwoFactorCode { get; set; } = null!;
    }
}
