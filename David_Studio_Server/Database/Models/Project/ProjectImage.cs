using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Project
{
    public class ProjectImage : Identity
    {
        public string Url { get; set; } = null!;
        public int ProjectId { get; set; }

        [JsonIgnore]
        public virtual Project? Project { get; set; }
    }
}
