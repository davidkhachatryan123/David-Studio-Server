using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Translation
{
    public class Translation : Identity
    {
        public string Text { get; set; } = null!;
        public int LanguageId { get; set; }

        [JsonIgnore]
        public virtual Language? Language { get; set; }
    }
}
