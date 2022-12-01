using System.ComponentModel.DataAnnotations;

namespace David_Studio_Server.Models
{
    public class TwoFactorModel
    {
        [Required]
        public string TwoFactorCode { get; set; } = null!;
    }
}
