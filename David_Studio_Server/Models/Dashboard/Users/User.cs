namespace David_Studio_Server.Models.Dashboard.Users
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string Role { get; set; } = null!;

        public User(
            string Id,
            string Username,
            string Email,
            string Phone,
            string Role)
        {
            this.Id = Id;
            this.Username = Username;
            this.Email = Email;
            this.Phone = Phone;
            this.Role = Role;
        }
    }
}
