using David_Studio_Server.Database.Models.Authentication;
using David_Studio_Server.Models;
using David_Studio_Server.Models.Auth;
using David_Studio_Server.Models.Dashboard.Users;
using David_Studio_Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace David_Studio_Server.Controllers.Admin.Dashboard.Users
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/admin/users/[controller]")]
    [ApiController]
    public class Admins : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmail _email;

        public Admins(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmail email)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _email = email;
        }

        Func<User, Object> orderByFunc = null!;

        [HttpGet]
        public async Task<UsersResponse> Get(
            [FromQuery] string Sort,
            [FromQuery] string OrderDirection,
            [FromQuery] int Page,
            [FromQuery] int PageSize)
        {
            switch (Sort.ToLower())
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

                users.Add(new User(AppUser.Id, AppUser.UserName, AppUser.Email, AppUser.EmailConfirmed, AppUser.PhoneNumber, roles.First()));
            }

            IEnumerable<User> result =
                OrderDirection == "asc" ? users.OrderBy(orderByFunc) : users.OrderByDescending(orderByFunc);

            return new UsersResponse(result, await _userManager.Users.CountAsync());
        }

        [HttpPost]
        public async Task<ResponseModel> Post([FromBody] NewUser newUser)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = newUser.Username,
                Email = newUser.Email,
                PhoneNumber = newUser.Phone,
                TwoFactorEnabled = true
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);

            result = await _userManager.AddToRoleAsync(user, newUser.Role);

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", nameof(Auth), new { token, email = user.Email }, Request.Scheme);
                var emailBody = _email.GetEmailConfirmationPage(confirmationLink!);

                bool emailResponse = _email.SendEmail(user.Email, "David Studio - Email Confirmation", emailBody);

                if (emailResponse)
                    return new ResponseModel($"Confirmation link sended, to {user.Email}. Please ask to check mailbox!", StatusCodes.Status200OK);
            }

            return new ResponseModel("Internal server error, please try again later!", StatusCodes.Status500InternalServerError);
        }
    }
}
