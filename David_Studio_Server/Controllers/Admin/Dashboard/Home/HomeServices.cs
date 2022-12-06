using David_Studio_Server.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace David_Studio_Server.Controllers.Admin.Dashboard.Home
{
    [Authorize(Roles = UserRoles.Admin + ", " + UserRoles.Manager)]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class HomeServices : ControllerBase
    {
        
    }
}
