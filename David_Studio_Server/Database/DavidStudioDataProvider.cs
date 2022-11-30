using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace David_Studio_Server.Database
{
    public interface IDavidStudioDataProvider
    {
        //Task<string> GetServicesForHome(string culture);

        /*Task<string> GetProjectsList(int Count);
        Task<string> GetTagsList(int count, string? value);*/
    }

    public class DavidStudioDataProvider : IDavidStudioDataProvider
    {
        private readonly davidstudioContext _context;

        public DavidStudioDataProvider(davidstudioContext context)
        {
            _context = context;
        }

        /*public async Task<string> GetServicesForHome(string culture)
        {
            var result = await _context.Services
                .Include(s => s.Translations)
                .ThenInclude(t => t!.Language)
                .Select(s => new
                {
                    id = s.Id,
                    title = s.Translations.Where(x => x.Language!.Culture == culture).First().Title,
                    description = s.Translations.Where(x => x.Language!.Culture == culture).First().Description,
                    img_url = s.ImgUrl,
                    path = s.Path!.Value
                })
                .ToListAsync();

            return JsonSerializer.Serialize(result);
        }*/

        /*public async Task<string> GetProjectsList(int Count)
        {
            var result = await _context.Projects.Include(p => p.Tags).ThenInclude(pt => pt.Tag)
                .Select(p => new
                {
                    id = p.Id,
                    title = p.Title,
                    popularity = p.Popularity,
                    tags = p.Tags.Select(t => new
                    {
                        name = t.Tag.Name,
                    })
                })
                .OrderByDescending(o => o.popularity)
                .Take(Count)
                .ToListAsync();

            return JsonSerializer.Serialize(result);
        }

        public async Task<string> GetTagsList(int count, string? value)
        {
            IEnumerable<Tag> result;

            if (value != null)
            {
                value = value.ToLower();

                List<Tag> longName_Tags = await _context.Tags.Where(t => t.LongName!.Contains(value))
                    .Take(count).ToListAsync();
                List<Tag> name_Tags = await _context.Tags.Where(t => t.Name.Contains(value))
                    .Take(count - longName_Tags.Count).ToListAsync();

                result = longName_Tags.UnionBy(name_Tags, t => t.Id);
            }
            else
            {
                result = await _context.Tags.Take(count).ToListAsync();
            }

            return JsonSerializer.Serialize(result);
        }*/
    }
}
