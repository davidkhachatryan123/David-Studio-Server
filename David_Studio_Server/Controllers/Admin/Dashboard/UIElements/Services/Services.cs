using David_Studio_Server.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace David_Studio_Server.Controllers.Admin.Dashboard.UIElements.Services
{
    [Authorize(Roles = UserRoles.Admin + ", " + UserRoles.Manager)]
    [Route("api/Admin/UIElements/[controller]")]
    [ApiController]
    public class Services : ControllerBase
    {

    }
}
