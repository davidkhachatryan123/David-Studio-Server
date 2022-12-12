namespace David_Studio_Server.ViewModels.Dashboard.Users
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool EmailConfirmed { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; } = null!;

        public UserViewModel(
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
