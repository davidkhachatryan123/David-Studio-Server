using David_Studio_Server.Database.Enums;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models
{
    public partial class Project
    {
        public Project()
        {
            Images = new HashSet<ProjectImage>();
            Tags = new HashSet<ProjectTag>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ImgLink { get; set; }
        public Popularity Popularity { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProjectImage> Images { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProjectTag> Tags { get; set; }
    }
}
