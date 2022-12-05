using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Content.Services
{
    public class Service : Identity
    {
        public Service()
        {
            ServiceTranslations = new HashSet<ServiceTranslation>();
        }

        public string GroupName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string ButtonColor { get; set; } = null!;
        public string Href { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<ServiceTranslation> ServiceTranslations { get; set; }
    }
}
