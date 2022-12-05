using David_Studio_Server.Database;

namespace David_Studio_Server.Services
{
    public interface IDavidStudioDataProvider
    {
        
    }

    public class HomeServiceDataProvider : IDavidStudioDataProvider
    {
        private readonly DavidStudioContext _context;

        public HomeServiceDataProvider(DavidStudioContext context)
        {
            _context = context;
        }
    }
}
