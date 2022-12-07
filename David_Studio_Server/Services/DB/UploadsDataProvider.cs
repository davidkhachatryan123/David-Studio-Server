using David_Studio_Server.Database;

namespace David_Studio_Server.Services.DB
{
    public interface IUploadsDataProvider
    {
        Task AddFileInfo(IEnumerable<Database.Models.Content.Uploads.File> files);
    }

    public class UploadsDataProvider : IUploadsDataProvider
    {
        private readonly DavidStudioContext _context;

        public UploadsDataProvider(DavidStudioContext context)
        {
            _context = context;
        }

        public async Task AddFileInfo(
            IEnumerable<Database.Models.Content.Uploads.File> files)
        {
            await _context.Files.AddRangeAsync(files);

            await _context.SaveChangesAsync();
        }
    }
}
