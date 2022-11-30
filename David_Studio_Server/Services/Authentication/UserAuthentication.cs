using David_Studio_Server.Database;
using David_Studio_Server.Database.Models.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace David_Studio_Server.Services.Authentication
{
    public interface IUserAuthentication
    {
        Task<User> GetUserWithLogin(string Login);
    }

    public class UserAuthentication : IUserAuthentication
    {
        private readonly davidstudioContext _context;

        public UserAuthentication(davidstudioContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserWithLogin(string Login)
        {
            return await _context.Users.Include(u => u.UserRole).FirstOrDefaultAsync(user => user.Login == Login);
        }
    }
}
