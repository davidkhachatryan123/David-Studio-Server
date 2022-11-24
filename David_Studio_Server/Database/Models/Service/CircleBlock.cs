using David_Studio_Server.Database.Base;

namespace David_Studio_Server.Database.Models.Service
{
    public class CircleBlock : Identity
    {
        public string Title { get; set; } = null!;
        public int ServiceId { get; set; }
    }
}
