using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Path
{
    public class Jumbotron : Identity
    {
        public int PathId { get; set; }
        public int TitleTranslationId { get; set; }
        public int DescriptionTranslationId { get; set; }

        [JsonIgnore]
        public virtual Path? Path { get; set; }
        [JsonIgnore]
        public virtual Translation.Translation? TitleTranslation { get; set; }
        [JsonIgnore]
        public virtual Translation.Translation? DescriptionTranslation { get; set; }
    }
}
