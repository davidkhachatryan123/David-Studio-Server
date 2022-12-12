using David_Studio_Server.Database;
using David_Studio_Server.Database.Models.Content.Services;
using David_Studio_Server.Database.Models.Content.Translation;
using David_Studio_Server.ViewModels.Dashboard.Home;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace David_Studio_Server.Services.DB.Home
{
    public interface IHomeServicesDataProvider
    {
        Task<IEnumerable<Service>> GetServicesAsync();

        Task<bool> AddNewHomeServiceAsync(HomeServiceData homeServiceData);
        Task<bool> UpdateHomeServiceAsync(HomeServiceData homeServiceData);

        Task<HomeServiceData?> GetHomeServiceDataAsync(int ServiceId);
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
            try
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

                HomeService? homeService = await _context.HomeServices
                    .FirstOrDefaultAsync(x => x.Id == homeServiceData.HomeServiceId);

                if (title != null && description != null && homeService != null)
                {
                    title.Text = homeServiceData.Title;
                    description.Text = homeServiceData.Description;

                    homeService.ButtonColor = homeServiceData.ButtonColor;
                    homeService.ImageId = homeServiceData.ImageId;

                    _context.UpdateRange(title, description);
                    _context.Update(homeService);

                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<HomeServiceData?> GetHomeServiceDataAsync(int ServiceId)
        {
            Service? service = await _context.Services
                .Include(x => x.HomeService)
                .ThenInclude(x => x.HomeServiceTranslations)
                .ThenInclude(x => x.TitleTranslation)

                .Include(x => x.HomeService)
                .ThenInclude(x => x.HomeServiceTranslations)
                .ThenInclude(x => x.DescriptionTranslation)

                .ThenInclude(x => x.Language)

                .FirstOrDefaultAsync(x => x.Id == ServiceId);

            if (service.HomeService == null) return null;

            return new HomeServiceData()
            {
                ServiceId = service.Id,
                HomeServiceId = service.HomeService.Id,
                LanguageId = service.HomeService.HomeServiceTranslations.FirstOrDefault()!.TitleTranslation.LanguageId,
                Title = service.HomeService.HomeServiceTranslations.FirstOrDefault()!.TitleTranslation.Text,
                Description = service.HomeService.HomeServiceTranslations.FirstOrDefault()!.DescriptionTranslation.Text,
                ButtonColor = service.HomeService.ButtonColor,
                ImageId = service.HomeService.ImageId
            };
        }
    }
}
