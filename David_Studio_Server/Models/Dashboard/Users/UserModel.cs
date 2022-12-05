namespace David_Studio_Server.Models.Dashboard.Users
{
    public class UserModel
    {
        public string Id { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool EmailConfirmed { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; } = null!;

        public UserModel(
            string Id,
            string Username,
            string Email,
            bool EmailConfirmed,
            string Phone,
            string Role)
        {
            this.Id = Id;
            this.Username = Username;
            this.Email = Email;
            this.EmailConfirmed = EmailConfirmed;
            this.Phone = Phone;
            this.Role = Role;
        }
    }
}
