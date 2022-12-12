namespace David_Studio_Server.ViewModels.Dashboard.Users
{
    public class NewUserModel
    {
        public string Id { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Role { get; set; } = null!;
    }
}
