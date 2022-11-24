using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Service
{
    public class Service : Identity
    {
        public Service()
        {
            CircleBlocks = new HashSet<CircleBlock>();
        }

        public string ImgUrl { get; set; } = null!;
        public int TitleTranslationId { get; set; }
        public int DescriptionTranslationId { get; set; }
        public int PathId { get; set; }

        [JsonIgnore]
        public virtual ICollection<CircleBlock> CircleBlocks { get; set; }
        [JsonIgnore]
        public virtual Path.Path? Path { get; set; }
        [JsonIgnore]
        public virtual Translation.Translation? TitleTranslation { get; set; }
        [JsonIgnore]
        public virtual Translation.Translation? DescriptionTranslation { get; set; }
    }
}
