using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Content.Services
{
    public class ServiceTranslation : Identity
    {
        public int ServiceId { get; set; }
        public int TitleTranslationId { get; set; }
        public int DescriptionTranslationId { get; set; }

        [JsonIgnore]
        public virtual Service Service { get; set; } = null!;
        [JsonIgnore]
        public virtual Translation.Translation TitleTranslation { get; set; } = null!;
        [JsonIgnore]
        public virtual Translation.Translation DescriptionTranslation { get; set; } = null!;
    }
}
