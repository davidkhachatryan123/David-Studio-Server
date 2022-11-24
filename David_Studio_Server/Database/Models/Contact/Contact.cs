using David_Studio_Server.Database.Base;

namespace David_Studio_Server.Database.Models.Contact
{
    public class Contact : Identity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Message { get; set; } = null!;
    }
}
