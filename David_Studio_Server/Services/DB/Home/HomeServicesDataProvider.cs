using David_Studio_Server.Database;
using Microsoft.EntityFrameworkCore;

namespace David_Studio_Server.Services.DB.Home
{
    public interface IHomeServicesDataProvider
    {
        Task<IEnumerable<string>> GetGroupsAsync();
    }

    public class HomeServicesDataProvider : IHomeServicesDataProvider
    {
        private readonly DavidStudioContext _context;

        public HomeServicesDataProvider(DavidStudioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetGroupsAsync()
        {
            return await _context.Services
                .Select(x => x.GroupName)
                .Distinct()
                .ToArrayAsync();
        }
    }
}
