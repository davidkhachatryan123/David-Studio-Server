using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Content.Services;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Content.Uploads
{
    public class Image : Identity
    {

        public Image()
        {
            Services = new HashSet<Service>();
        }

        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Service> Services { get; set; }
    }
}
