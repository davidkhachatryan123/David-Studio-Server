using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Content.Uploads;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Content.Services
{
    public class Service : Identity
    {
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual HomeService HomeService { get; set; } = null!;
    }
}
