using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Content.Services
{
    public class HomeServiceTranslation : Identity
    {
        public int HomeServiceId { get; set; }
        public int TitleTranslationId { get; set; }
        public int DescriptionTranslationId { get; set; }

        [JsonIgnore]
        public virtual HomeService HomeService { get; set; } = null!;
        [JsonIgnore]
        public virtual Translation.Translation TitleTranslation { get; set; } = null!;
        [JsonIgnore]
        public virtual Translation.Translation DescriptionTranslation { get; set; } = null!;
    }
}
