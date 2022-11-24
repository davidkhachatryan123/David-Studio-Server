using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Translation;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Path
{
    public class Jumbotron : Identity
    {
        public Jumbotron()
        {
            Translations = new HashSet<TemplateTranslation>();
        }

        public int PathId { get; set; }

        [JsonIgnore]
        public virtual Path? Path { get; set; }

        [JsonIgnore]
        public virtual ICollection<TemplateTranslation> Translations { get; set; }
    }
}
