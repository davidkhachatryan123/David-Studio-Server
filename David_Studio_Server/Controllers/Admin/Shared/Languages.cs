using David_Studio_Server.Database.Models.Content.Translation;
using David_Studio_Server.Services.DB.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace David_Studio_Server.Controllers.Admin.Shared
{
    [Authorize]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class Languages : ControllerBase
    {
        private readonly ILanguagesDataProvider _languages;

        public Languages(ILanguagesDataProvider languages)
        {
            _languages = languages;
        }

        [HttpGet]
        public async Task<IEnumerable<Language>> GetLanguages()
        {
            return await _languages.GetLanguagesAsync();
        }
    }
}
