using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Content.Translation
{
    public class Language : Identity
    {
        public Language()
        {
            Translations = new HashSet<Translation>();
        }

        public string Name { get; set; } = null!;
        public string Culture { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Translation> Translations { get; set; }
    }
}
