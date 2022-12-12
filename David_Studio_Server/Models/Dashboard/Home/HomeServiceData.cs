using David_Studio_Server.Database.Models.Content.Services;
using David_Studio_Server.Database.Models.Content.Translation;

namespace David_Studio_Server.Models.Dashboard.Home
{
    public class HomeServiceData
    {
        public int HomeServiceId { get; set; }

        public int ServiceId { get; set; }
        public int LanguageId { get; set; }

        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ButtonColor { get; set; } = null!;
        public int ImageId { get; set; }
    }
}
