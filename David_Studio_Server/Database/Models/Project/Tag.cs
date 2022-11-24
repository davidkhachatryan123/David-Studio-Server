using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Service;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Project
{
    public class Tag : Identity
    {
        public Tag()
        {
            Projects = new HashSet<ProjectTag>();
        }

        public string Name { get; set; } = null!;
        public string? LongName { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProjectTag> Projects { get; set; }
        [JsonIgnore]
        public virtual Circle? Circle { get; set; }
    }
}
