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
            Circles = new HashSet<Circle>();
        }

        public string Name { get; set; } = null!;
        public string? LongName { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProjectTag> Projects { get; set; }
        [JsonIgnore]
        public virtual ICollection<Circle> Circles { get; set; }
    }
}
