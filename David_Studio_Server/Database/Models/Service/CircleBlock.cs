using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Service
{
    public class CircleBlock : Identity
    {
        public CircleBlock()
        {
            Circles = new HashSet<Circle>();
        }

        public string Title { get; set; } = null!;
        public int ServiceId { get; set; }

        [JsonIgnore]
        public virtual Service? Service { get; set; }
        [JsonIgnore]
        public virtual ICollection<Circle> Circles { get; set; }
    }
}
