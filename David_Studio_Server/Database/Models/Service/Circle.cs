using David_Studio_Server.Database.Base;

namespace David_Studio_Server.Database.Models.Service
{
    public class Circle : Identity
    {
        public int TagId { get; set; }
        public int CircleBlockId { get; set; }
    }
}
