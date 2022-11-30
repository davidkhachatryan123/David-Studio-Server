using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Authentication
{
    public class User : Identity
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public int UserGroupId { get; set; }

        [JsonIgnore]
        public virtual UserGroup? UserGroup { get; set; }
    }
}
