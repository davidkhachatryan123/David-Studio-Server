using David_Studio_Server.Database;

namespace David_Studio_Server.Services.DB
{
    public interface IUploadsDataProvider
    {
        Task AddImagesInfo(IEnumerable<Database.Models.Content.Uploads.Image> images);
    }

    public class UploadsDataProvider : IUploadsDataProvider
    {
        private readonly DavidStudioContext _context;

        public UploadsDataProvider(DavidStudioContext context)
        {
            _context = context;
        }

        public async Task AddImagesInfo(
            IEnumerable<Database.Models.Content.Uploads.Image> images)
        {
            await _context.Images.AddRangeAsync(images);

            await _context.SaveChangesAsync();
        }
    }
}
