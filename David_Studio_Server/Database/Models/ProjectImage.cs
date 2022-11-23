using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models
{
    public partial class ProjectImage
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public int ProjectId { get; set; }

        [JsonIgnore]
        public virtual Project Project { get; set; } = null!;
    }
}
