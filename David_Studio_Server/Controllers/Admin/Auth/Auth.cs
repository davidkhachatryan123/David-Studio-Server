using David_Studio_Server.Database.Models.Authentication;
using David_Studio_Server.ViewModels;
using David_Studio_Server.ViewModels.Auth;
using David_Studio_Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace David_Studio_Server.Controllers.Admin.Auth
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IConfiguration _configuration;
        private readonly IEmail _email;

        public Auth(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            IEmail email)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _email = email;
        }

        [Authorize]
        [Route("GetUser")]
        [HttpGet]
        public async Task<ClientUserModel> GetUser()
        {
            var appUser = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(appUser);

            return new ClientUserModel()
            {
                UserName = appUser.UserName,
                Email = appUser.Email,
                PhoneNumber = appUser.PhoneNumber,
                Role = roles.First()
            };
        }


        [Route("IsSetup")]
        [HttpGet]
        public bool IsSetup()
        {
            return !_userManager.Users.Any();
        }

        [Route("IsLoggedIn")]
        [HttpGet]
        public bool IsLoggedIn()
        {
            return HttpContext.Request.Cookies.ContainsKey(".AspNetCore.Identity.Application");
        }


        [Route("Setup")]
        [HttpPost]
        public async Task<ResponseModel> Setup([FromBody] SetupModel registerModel)
        {
            if (!_userManager.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = registerModel.Username,
                    Email = registerModel.Email,
                    TwoFactorEnabled = true
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);

                result = await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                result = await _roleManager.CreateAsync(new IdentityRole(UserRoles.Manager));

                result = await _userManager.AddToRoleAsync(user, UserRoles.Admin);

                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", nameof(Auth), new { token, email = user.Email }, Request.Scheme);

                    bool sended = _email.SendConfirmEmailAsync(user, confirmationLink!);

                    if (sended)
                        return new ResponseModel(
                            "Confirmation link sended, to your email. Please check your inbox!",
                            StatusCodes.Status200OK);
                }


                return new ResponseModel("Internal server error, please try again later!", StatusCodes.Status500InternalServerError);
            }

            return new ResponseModel("Root user are registered", StatusCodes.Status405MethodNotAllowed);
        }

        [Route("ConfirmEmail")]
        [HttpGet]
        public async Task<ContentResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    return base.Content(_email.RedirectToLogin(_configuration["Client:Login"]), "text/html");
                }
            }

            return base.Content("Error: " + StatusCodes.Status401Unauthorized);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ResponseModel> LoginOneStep([FromBody] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? user = await _userManager.FindByNameAsync(userModel.Username);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userModel.Password, false, false);

                    if (result.RequiresTwoFactor)
                    {
                        await SendTwoFactorTokenAsync(user.Email);

                        return new ResponseModel("Two factor authentication code sended to Email: " + user.Email, StatusCodes.Status200OK);
                    }
                }
            }

            return new ResponseModel("User authentication error!", StatusCodes.Status401Unauthorized);
        }

        [Route("LoginTwoFactor")]
        [HttpPost]
        public async Task<ResponseModel> LoginTwoStep(TwoFactorModel twoFactor)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.TwoFactorSignInAsync("Email", twoFactor.TwoFactorCode, false, false);

                if (result.Succeeded)
                    return new ResponseModel("User successffuly authenticated!", StatusCodes.Status200OK);
            }


            return new ResponseModel("User authentication error!", StatusCodes.Status401Unauthorized);
        }

        [Authorize]
        [Route("SignOut")]
        [HttpGet]
        public async Task<IResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return Results.Ok();
        }


        private async Task<bool> SendTwoFactorTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
            var content = _email.Get2FAEmailBody(token);

            return _email.SendEmail(user.Email, "David Studio - Two Factor 6 digits Code", content);
        }
    }
}
