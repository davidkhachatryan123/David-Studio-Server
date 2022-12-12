using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Content.Services
{
    public class HomeService : Identity
    {
        public HomeService()
        {
            HomeServiceTranslations = new HashSet<HomeServiceTranslation>();
        }

        public string ButtonColor { get; set; } = null!;
        public int ImageId { get; set; }
        public int ServiceId { get; set; }

        [JsonIgnore]
        public virtual Uploads.File Image { get; set; } = null!;
        [JsonIgnore]
        public virtual Service Service { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<HomeServiceTranslation> HomeServiceTranslations { get; set; }
    }
}
