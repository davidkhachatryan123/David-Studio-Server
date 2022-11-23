using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Projects = new HashSet<ProjectTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? LongName { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProjectTag> Projects { get; set; }
    }
}
