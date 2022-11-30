using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Authentication
{
    public class User : Identity
    {
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public int UserRoleId { get; set; }

        [JsonIgnore]
        public virtual UserRole? UserRole { get; set; }
    }
}
