using David_Studio_Server.Database.Base;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Service
{
    public class Circle : Identity
    {
        public int TagId { get; set; }
        public int CircleBlockId { get; set; }

        [JsonIgnore]
        public virtual CircleBlock? CircleBlock { get; set; }
    }
}
