using David_Studio_Server.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace David_Studio_Server.Services
{
    public interface IDavidStudioDataProvider
    {
        
    }

    public class DavidStudioDataProvider : IDavidStudioDataProvider
    {
        private readonly DavidStudioContext _context;

        public DavidStudioDataProvider(DavidStudioContext context)
        {
            _context = context;
        }
    }
}
