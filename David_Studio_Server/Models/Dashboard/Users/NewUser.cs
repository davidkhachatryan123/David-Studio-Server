﻿namespace David_Studio_Server.Models.Dashboard.Users
{
    public class NewUser
    {
        public string Id { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string Role { get; set; } = null!;
    }
}
