using David_Studio_Server.Database.Models.Content.Services;
using David_Studio_Server.Models;
using David_Studio_Server.Models.Dashboard.Home;
using David_Studio_Server.Services.DB.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace David_Studio_Server.Controllers.Admin.Dashboard.Home
{
    [Authorize]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class HomeServices : ControllerBase
    {
        private readonly IHomeServicesDataProvider _homeServices;

        public HomeServices(IHomeServicesDataProvider homeServices)
        {
            _homeServices = homeServices;
        }

        [Route("services")]
        [HttpGet]
        public async Task<IEnumerable<Service>> GetServices()
        {
            return await _homeServices.GetServicesAsync();
        }

        [HttpPost]
        public async Task<ResponseModel> DataUpdate([FromBody] HomeServiceData homeServiceData)
        {
            var result = await _homeServices.UpdateHomeServiceAsync(homeServiceData);

            return new ResponseModel("", StatusCodes.Status200OK);
        }
    }
}
