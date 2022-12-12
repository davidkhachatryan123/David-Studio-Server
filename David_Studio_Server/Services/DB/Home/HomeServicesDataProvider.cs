using David_Studio_Server.Database;
using David_Studio_Server.Database.Models.Content.Services;
using David_Studio_Server.Database.Models.Content.Translation;
using David_Studio_Server.Models.Dashboard.Home;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace David_Studio_Server.Services.DB.Home
{
    public interface IHomeServicesDataProvider
    {
        Task<IEnumerable<Service>> GetServicesAsync();
        Task<bool> AddNewHomeServiceAsync(HomeServiceData homeServiceData);
        Task<bool> UpdateHomeServiceAsync(HomeServiceData homeServiceData);
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

        public async Task<bool> AddNewHomeServiceAsync(HomeServiceData homeServiceData)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                Service? service = await _context.Services.FirstOrDefaultAsync(x => x.Id == homeServiceData.ServiceId);
                Language? lang = await _context.Languages.FirstOrDefaultAsync(x => x.Id == homeServiceData.LanguageId);

                if (service != null && lang != null)
                {
                    HomeService homeService = new()
                    {
                        ServiceId = service.Id,
                        ImageId = homeServiceData.ImageId,
                        ButtonColor = homeServiceData.ButtonColor
                    };

                    await _context.HomeServices.AddAsync(homeService);
                    await _context.SaveChangesAsync();


                    Translation title = new()
                    {
                        Language = lang,
                        Text = homeServiceData.Title
                    },
                    description = new()
                    {
                        Language = lang,
                        Text = homeServiceData.Description
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

                    await transaction.CommitAsync();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateHomeServiceAsync(HomeServiceData homeServiceData)
        {
            Translation? title = await _context.Translations
                .Include(x => x.Language)
                .Include(x => x.ServiceTitleTranslations.Where(y => y.HomeServiceId == homeServiceData.HomeServiceId))
                .Where(x => x.Language.Id == homeServiceData.LanguageId)
                .Where(x => x.ServiceTitleTranslations.Any())
                .FirstOrDefaultAsync();

            Translation? description = await _context.Translations
                .Include(x => x.Language)
                .Include(x => x.ServiceDescriptionTranslations.Where(y => y.HomeServiceId == homeServiceData.HomeServiceId))
                .Where(x => x.Language.Id == homeServiceData.LanguageId)
                .Where(x => x.ServiceDescriptionTranslations.Any())
                .FirstOrDefaultAsync();



            return true;
        }
    }
}
