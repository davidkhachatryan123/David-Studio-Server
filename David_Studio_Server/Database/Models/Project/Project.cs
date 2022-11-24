using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Enums;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Project
{
    public class Project : Identity
    {
        public Project()
        {
            Tags = new HashSet<ProjectTag>();
            Images = new HashSet<ProjectImage>();
        }

        public string Title { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public Popularity Popularity { get; set; }
        public int PathId { get; set; }

        [JsonIgnore]
        public virtual Path.Path? Path { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProjectTag> Tags { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProjectImage> Images { get; set; }
    }
}
