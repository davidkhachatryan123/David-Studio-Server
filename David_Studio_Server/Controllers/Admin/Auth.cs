using David_Studio_Server.Database.Models.Authentication;
using David_Studio_Server.Models;
using David_Studio_Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace David_Studio_Server.Controllers.Admin
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

        [Authorize(Roles = UserRoles.Admin)]
        [Route("Test")]
        [HttpGet]
        public string Test()
        {
            return "Hello World!";
        }

        [Route("Setup")]
        [HttpPost]
        public async Task<ResponseModel> Setup([FromBody] RegisterModel registerModel)
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

                    bool emailResponse = _email.SendEmail(user.Email, confirmationLink!);

                    if (emailResponse)
                        return new ResponseModel("Confirmation link sended, to your email. Please check your email!", StatusCodes.Status200OK);
                }


                return new ResponseModel("Internal server error, please try again later!", StatusCodes.Status500InternalServerError);
            }

            return new ResponseModel("Root user are registered", StatusCodes.Status405MethodNotAllowed);
        }

        [Route("IsSetup")]
        [HttpGet]
        public IResult IsSetup()
        {
            if (_userManager.Users.Any())
                return Results.Json("false");

            return Results.Json("true");
        }

        [Route("ConfirmEmail")]
        [HttpGet]
        public async Task<IResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                    return Results.Ok();
            }

            return Results.Unauthorized();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IResult> LoginOneStep([FromBody] UserModel userModel)
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

                        return Results.Json(new { message = "Two factor authentication code sended to Email: " + user.Email });
                    }
                }
            }

            return Results.Unauthorized();
        }

        [Route("LoginTwoFactor")]
        [HttpPost]
        public async Task<IResult> LoginTwoStep(TwoFactorModel twoFactor)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.TwoFactorSignInAsync("Email", twoFactor.TwoFactorCode, false, false);

                if (result.Succeeded)
                    return Results.Ok();
            }


            return Results.Unauthorized();
        }


        private async Task<bool> SendTwoFactorTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

            return _email.SendEmail(user.Email, token);
        }
    }
}
