using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Authentication
{
    public class UserRole : Identity
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public string Role { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
