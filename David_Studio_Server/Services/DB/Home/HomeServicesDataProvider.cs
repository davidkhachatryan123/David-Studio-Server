using David_Studio_Server.Database;
using David_Studio_Server.Database.Models.Content.Services;
using Microsoft.EntityFrameworkCore;

namespace David_Studio_Server.Services.DB.Home
{
    public interface IHomeServicesDataProvider
    {
        Task<IEnumerable<Service>> GetGroupsAsync();
    }

    public class HomeServicesDataProvider : IHomeServicesDataProvider
    {
        private readonly DavidStudioContext _context;

        public HomeServicesDataProvider(DavidStudioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetGroupsAsync()
        {
            return await _context.Services
                .ToArrayAsync();
        }
    }
}
