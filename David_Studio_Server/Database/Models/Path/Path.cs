using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Path
{
    public class Path : Identity
    {
        public string Value { get; set; } = null!;

        [JsonIgnore]
        public virtual Jumbotron? Jumbotron { get; set; }
        [JsonIgnore]
        public virtual Project.Project? Project { get; set; }
        [JsonIgnore]
        public virtual Service.Service? Service { get; set; }
    }
}
