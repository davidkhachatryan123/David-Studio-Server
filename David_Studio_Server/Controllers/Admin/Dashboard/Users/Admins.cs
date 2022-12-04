using David_Studio_Server.Database.Models.Authentication;
using David_Studio_Server.Models.Auth;
using David_Studio_Server.Models.Dashboard.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace David_Studio_Server.Controllers.Admin.Dashboard.Users
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/admin/users/[controller]")]
    [ApiController]
    public class Admins : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Admins(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        Func<User, Object> orderByFunc = null!;

        [HttpGet]
        public async Task<IEnumerable<User>> Get(
            [FromQuery] string Sort,
            [FromQuery] string OrderDirection,
            [FromQuery] int Page,
            [FromQuery] int PageSize)
        {
            switch (Sort)
            {
                case UsersSort.Id:
                    orderByFunc = x => x.Id;
                    break;
                case UsersSort.Username:
                    orderByFunc = x => x.Username;
                    break;
                case UsersSort.Email:
                    orderByFunc = x => x.Email;
                    break;
                case UsersSort.Phone:
                    orderByFunc = x => x.Phone;
                    break;
                case UsersSort.Role:
                    orderByFunc = x => x.Role;
                    break;
            }

            List<User> users = new List<User>();

            IEnumerable<ApplicationUser> AppUsers =
                await _userManager.Users
                .Skip((Page - 1) * PageSize)
                .Take(PageSize)
                .ToArrayAsync();

            foreach (ApplicationUser AppUser in AppUsers)
            {
                var roles = await _userManager.GetRolesAsync(AppUser);

                users.Add(new User(AppUser.Id, AppUser.UserName, AppUser.Email, AppUser.PhoneNumber, roles.First()));
            }

            IEnumerable<User> result =
                OrderDirection == "asc" ? users.OrderBy(orderByFunc) : users.OrderByDescending(orderByFunc);

            return result;
        }
    }
}
