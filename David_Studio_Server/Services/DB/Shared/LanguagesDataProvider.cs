using David_Studio_Server.Database;
using David_Studio_Server.Database.Models.Content.Translation;
using Microsoft.EntityFrameworkCore;

namespace David_Studio_Server.Services.DB.Shared
{
    public interface ILanguagesDataProvider
    {
        Task<IEnumerable<Language>> GetLanguagesAsync();
    }

    public class LanguagesDataProvider : ILanguagesDataProvider
    {
        private readonly DavidStudioContext _context;

        public LanguagesDataProvider(DavidStudioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            return await _context.Languages.ToArrayAsync();
        }
    }
}
