using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models
{
    public partial class ProjectTag
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TagId { get; set; }

        [JsonIgnore]
        public virtual Project Project { get; set; } = null!;
        [JsonIgnore]
        public virtual Tag Tag { get; set; } = null!;
    }
}
