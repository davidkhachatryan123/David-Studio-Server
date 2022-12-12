using David_Studio_Server.Database;
using David_Studio_Server.Database.Models.Content.Services;
using David_Studio_Server.ViewModels;
using David_Studio_Server.ViewModels.Dashboard.Home;
using David_Studio_Server.Services.DB.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace David_Studio_Server.Controllers.Admin.Dashboard.Home
{
    [Authorize]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class HomeServices : ControllerBase
    {
        private readonly IHomeServicesDataProvider _homeServices;
        private readonly DavidStudioContext _context;

        public HomeServices(
            IHomeServicesDataProvider homeServices,
            DavidStudioContext context)
        {
            _homeServices = homeServices;
            _context = context;
        }

        [Route("services")]
        [HttpGet]
        public async Task<IEnumerable<Service>> GetServices()
        {
            return await _homeServices.GetServicesAsync();
        }

        [HttpGet]
        public async Task<HomeServiceData?> Get(int ServiceId)
        {
            return await _homeServices.GetHomeServiceDataAsync(ServiceId);
        }

        [HttpPost]
        public async Task<ResponseModel> Post([FromBody] HomeServiceData homeServiceData)
        {
            bool result = false;

            HomeService? homeService = await _context.HomeServices
                .FirstOrDefaultAsync(x => x.Id == homeServiceData.HomeServiceId);

            if (homeService == null)
                result = await _homeServices.AddNewHomeServiceAsync(homeServiceData);
            else
            {
                result = await _homeServices.UpdateHomeServiceAsync(homeServiceData);
            }

            return new ResponseModel(result.ToString(), StatusCodes.Status200OK);
        }
    }
}
