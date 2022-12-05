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
        private IPasswordHasher<ApplicationUser> _passwordHasher;

        private readonly IEmail _email;

        public Admins(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEmail email)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _email = email;
        }

        Func<User, Object> orderByFunc = null!;

        [HttpGet]
        public async Task<UsersResponse> Get([FromQuery] UserListOptions options)
        {
            switch (options.Sort.ToLower())
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
                .Skip((options.Page - 1) * options.PageSize)
                .Take(options.PageSize)
                .ToArrayAsync();

            foreach (ApplicationUser AppUser in AppUsers)
            {
                var roles = await _userManager.GetRolesAsync(AppUser);

                users.Add(new User(AppUser.Id, AppUser.UserName, AppUser.Email, AppUser.EmailConfirmed, AppUser.PhoneNumber, roles.First()));
            }

            IEnumerable<User> result =
                options.OrderDirection == "asc" ? users.OrderBy(orderByFunc) : users.OrderByDescending(orderByFunc);

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

                bool sended = await _email.SendConfirmEmailAsync(user, confirmationLink!);

                if (sended)
                    return new ResponseModel(
                        $"Confirmation link sended, to {user.Email}. Please ask to check mailbox!",
                        StatusCodes.Status200OK);
            }

            return new ResponseModel("Internal server error, please try again later!", StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public async Task<ResponseModel> Put([FromBody] NewUser updateUser)
        {
            ApplicationUser appUser = await _userManager.FindByIdAsync(updateUser.Id);

            if (appUser != null)
            {
                if (!string.IsNullOrEmpty(updateUser.Username))
                    appUser.UserName = updateUser.Username;
                if (!string.IsNullOrEmpty(updateUser.Password))
                    appUser.PasswordHash = _passwordHasher.HashPassword(appUser, updateUser.Password);
                if (!string.IsNullOrEmpty(updateUser.Email))
                {
                    appUser.Email = updateUser.Email;
                    appUser.EmailConfirmed = false;
                }
                if (!string.IsNullOrEmpty(updateUser.Phone))
                    appUser.PhoneNumber = updateUser.Phone;
                if (!string.IsNullOrEmpty(updateUser.Role))
                {
                    await _userManager.RemoveFromRolesAsync(appUser, await _userManager.GetRolesAsync(appUser));
                    await _userManager.AddToRoleAsync(appUser, updateUser.Role);
                }

                var result = await _userManager.UpdateAsync(appUser);

                return ResponseModel.GetResponse(
                    result.Succeeded,
                    "User successfully updated!", StatusCodes.Status200OK,
                    "Internal server error, please try again later!", StatusCodes.Status500InternalServerError);
            }
            else
                return new ResponseModel("User not found!", StatusCodes.Status404NotFound);
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(string Id)
        {
            ApplicationUser appUser = await _userManager.FindByIdAsync(Id);

            if (appUser != null)
            {
                var result = await _userManager.DeleteAsync(appUser);

                return ResponseModel.GetResponse(
                    result.Succeeded,
                    "User successfully deleted!", StatusCodes.Status200OK,
                    "Internal server error, please try again later!", StatusCodes.Status500InternalServerError);
            }
            else
                return new ResponseModel("User not found!", StatusCodes.Status404NotFound);
        }

        [HttpGet]
        [Route("SendConfirmEmail")]
        public async Task<ResponseModel> SendConfirmEmail(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user != null)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", nameof(Auth), new { token, email = user.Email }, Request.Scheme);

                bool sended = await _email.SendConfirmEmailAsync(user, confirmationLink!);

                return ResponseModel.GetResponse(
                    sended,
                    "Confirmation link sended, to your email. Please check your inbox!", StatusCodes.Status200OK,
                    "Internal server error, please try again later!", StatusCodes.Status500InternalServerError);
            }
            else
                return new ResponseModel("User not found!", StatusCodes.Status404NotFound);
        }
    }
}
