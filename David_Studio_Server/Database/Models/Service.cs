using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace David_Studio_Server.Database.Models
{
    public partial class Service
    {
        public Service()
        {
            Tags = new HashSet<ProjectTag>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<ProjectTag> Tags { get; set; }
    }
}
