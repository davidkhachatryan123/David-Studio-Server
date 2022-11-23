using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models
{
    public partial class ServiceTag
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int TagId { get; set; }

        [JsonIgnore]
        public virtual Service Service { get; set; } = null!;
        [JsonIgnore]
        public virtual Tag Tag { get; set; } = null!;
    }
}
