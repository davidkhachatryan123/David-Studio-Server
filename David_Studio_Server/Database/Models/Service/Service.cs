using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Translation;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Service
{
    public class Service : Identity
    {
        public Service()
        {
            CircleBlocks = new HashSet<CircleBlock>();
            Translations = new HashSet<TemplateTranslation>();
        }

        public string ImgUrl { get; set; } = null!;
        public int PathId { get; set; }

        
        [JsonIgnore]
        public virtual Path.Path? Path { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<CircleBlock> CircleBlocks { get; set; }
        [JsonIgnore]
        public virtual ICollection<TemplateTranslation> Translations { get; set; }
    }
}
