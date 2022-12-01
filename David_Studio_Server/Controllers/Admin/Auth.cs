using David_Studio_Server.Database.Models.Authentication;
using David_Studio_Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace David_Studio_Server.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public Auth(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [Route("test")]
        [HttpPost]
        public IResult Test()
        {
            return Results.Ok("Hello World!");
        }

        [Route("setup")]
        [HttpPost]
        public async Task<IResult> Setup([FromBody] RegisterModel registerModel)
        {
            if (!_userManager.Users.Any())
            {
                var result = await _userManager.CreateAsync(new ApplicationUser()
                {
                    UserName = registerModel.Username,
                    Email = registerModel.Email
                }, registerModel.Password);

                if (!result.Succeeded)
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);

                return Results.Ok();
            }

            return Results.StatusCode(StatusCodes.Status405MethodNotAllowed);
        }

        [Route("login")]
        [HttpPost]
        public async Task<IResult> Login([FromBody] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? user = await _userManager.FindByNameAsync(userModel.Username);

                var res = await _signInManager.CheckPasswordSignInAsync(user!, userModel.Password, true);

                if (user != null && res.Succeeded)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    List<Claim> authClaims = new List<Claim>();

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var token = GetToken(authClaims);

                    return Results.Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
            }

            return Results.Unauthorized();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JWT:LifeTimeInMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha512)
                );

            return token;
        }
    }
}
