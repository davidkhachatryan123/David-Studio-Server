using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Path;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Translation
{
    public class TemplateTranslation : Identity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? JumbotronId { get; set; }
        public int? ServiceId { get; set; }
        public int LanguageId { get; set; }

        [JsonIgnore]
        public virtual Service.Service? Service { get; set; }
        [JsonIgnore]
        public virtual Jumbotron? Jumbotron { get; set; }
        [JsonIgnore]
        public virtual Language? Language { get; set; }
    }
}
