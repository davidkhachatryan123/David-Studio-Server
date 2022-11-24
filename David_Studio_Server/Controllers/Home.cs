using David_Studio_Server.Database;
using Microsoft.AspNetCore.Mvc;

namespace David_Studio_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home : ControllerBase
    {
        private readonly IDavidStudioDataProvider _data;

        public Home(IDavidStudioDataProvider data)
        {
            this._data = data;
        }

        [Route("services")]
        [HttpGet]
        public async Task<string> GetServices([FromQuery] string culture)
        {
            return await _data.GetServicesForHome(culture);
        }
    }
}
