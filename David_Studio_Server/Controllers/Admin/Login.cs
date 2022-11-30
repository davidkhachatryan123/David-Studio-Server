using David_Studio_Server.Database;
using Microsoft.AspNetCore.Mvc;

namespace David_Studio_Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        private readonly IDavidStudioDataProvider _data;

        public Login(IDavidStudioDataProvider data)
        {
            _data = data;
        }


    }
}
