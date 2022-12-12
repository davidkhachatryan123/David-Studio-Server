using David_Studio_Server.Controllers.Admin.Dashboard.Home;
using David_Studio_Server.Database;
using David_Studio_Server.Database.Models.Content.Services;
using David_Studio_Server.Database.Models.Content.Translation;
using David_Studio_Server.Models.Dashboard.Home;
using Microsoft.EntityFrameworkCore;

namespace David_Studio_Server.Services.DB.Home
{
    public interface IHomeServicesDataProvider
    {
        Task<IEnumerable<Service>> GetServicesAsync();
        Task<HomeService> UpdateHomeServiceAsync(HomeServiceData homeServicedata);
    }

    public class HomeServicesDataProvider : IHomeServicesDataProvider
    {
        private readonly DavidStudioContext _context;

        public HomeServicesDataProvider(DavidStudioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await _context.Services
                .ToArrayAsync();
        }

        public async Task<HomeService> UpdateHomeServiceAsync(HomeServiceData homeServicedata)
        {
            HomeService? homeService = await _context.HomeServices
                .FirstOrDefaultAsync(x => x.Id == homeServicedata.HomeServiceId);

            if (homeService == null)
            {
                await AddNewHomeServiceAsync(homeServicedata);
            }
            else
            {

            }

            await _context.SaveChangesAsync();

            return homeService;
        }

        private async Task<bool> AddNewHomeServiceAsync(HomeServiceData homeServicedata)
        {
            Service? service = await _context.Services.FirstOrDefaultAsync(x => x.Id == homeServicedata.ServiceId);
            Language? lang = await _context.Languages.FirstOrDefaultAsync(x => x.Id == homeServicedata.LanguageId);

            if (service != null && lang != null)
            {
                HomeService homeService = new()
                {
                    ServiceId = service.Id,
                    ImageId = homeServicedata.ImageId,
                    ButtonColor = homeServicedata.ButtonColor
                };

                await _context.HomeServices.AddAsync(homeService);
                await _context.SaveChangesAsync();


                Translation title = new()
                {
                    Language = lang,
                    Text = homeServicedata.Title
                },
                description = new()
                {
                    Language = lang,
                    Text = homeServicedata.Description
                };

                await _context.Translations.AddRangeAsync(title, description);
                await _context.SaveChangesAsync();


                HomeServiceTranslation homeServiceTranslation = new()
                {
                    HomeServiceId = homeService.Id,
                    TitleTranslationId = title.Id,
                    DescriptionTranslationId = description.Id
                };

                await _context.HomeServiceTranslations.AddAsync(homeServiceTranslation);
                await _context.SaveChangesAsync();
            }
            else return false;

            return true;
        }
    }
}
