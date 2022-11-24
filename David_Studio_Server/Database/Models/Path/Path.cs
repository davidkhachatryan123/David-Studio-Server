using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Project;
using David_Studio_Server.Database.Models.Service;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Path
{
    public class Path : Identity
    {
        public Path()
        {
            Jumbotrons = new HashSet<Jumbotron>();
            Projects = new HashSet<Project.Project>();
            Services = new HashSet<Service.Service>();
        }

        public string Value { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Jumbotron> Jumbotrons { get; set; }
        [JsonIgnore]
        public virtual ICollection<Project.Project> Projects { get; set; }
        [JsonIgnore]
        public virtual ICollection<Service.Service> Services { get; set; }
    }
}
