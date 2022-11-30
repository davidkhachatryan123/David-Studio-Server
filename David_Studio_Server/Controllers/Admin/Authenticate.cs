using David_Studio_Server.Database;
using David_Studio_Server.Database.Models.Authentication;
using David_Studio_Server.Models;
using David_Studio_Server.Services.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace David_Studio_Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authenticate : ControllerBase
    {
        private readonly IUserAuthentication _userAuthentication;
        private readonly ICryptography _cryptography;
        private readonly IConfiguration _configuration;

        public Authenticate(
            IUserAuthentication userAuthentication,
            ICryptography cryptography,
            IConfiguration configuration)
        {
            _userAuthentication = userAuthentication;
            _cryptography = cryptography;
            _configuration = configuration;
        }


        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IResult> Login([FromBody] LoginUser LoginUser)
        {
            User? _user = await _userAuthentication.GetUserWithLogin(LoginUser.Login);

            if (_user is null) return Results.Unauthorized();

            if (_user!.PasswordHash == _cryptography.HashPassword(_cryptography.CombinePasswordWithSalt(LoginUser.Password, _user!.Salt)))
            {
                var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, _user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, _user.UserRole!.Role),
                };

                var jwt = new JwtSecurityToken(
                                issuer: _configuration["JWT:Issuer"],
                                audience: _configuration["JWT:Audience"],
                                claims: claims,
                                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(5)),
                                signingCredentials: new SigningCredentials(
                                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                                    SecurityAlgorithms.HmacSha256));

                return Results.Json(new
                {
                    jwtToken = new JwtSecurityTokenHandler().WriteToken(jwt)
                });
            }

            return Results.Unauthorized();
        }
    }
}
