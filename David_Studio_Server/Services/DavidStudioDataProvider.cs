using David_Studio_Server.Database;
using David_Studio_Server.Database.Models.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace David_Studio_Server.Services
{
    public interface IDavidStudioDataProvider
    {
        
    }

    public class DavidStudioDataProvider : IDavidStudioDataProvider
    {
        private readonly davidstudioContext _context;

        public DavidStudioDataProvider(davidstudioContext context)
        {
            _context = context;
        }
    }
}
