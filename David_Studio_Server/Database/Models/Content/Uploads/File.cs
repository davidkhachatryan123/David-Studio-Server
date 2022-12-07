using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Content.Services;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Content.Uploads
{
    public class File : Identity
    {

        public File()
        {
            Services = new HashSet<Service>();
        }

        public string Name { get; set; } = null!;
        public string Path { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Service> Services { get; set; }
    }
}
