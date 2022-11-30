using David_Studio_Server.Database.Models.Authentication;
using System.Security.Cryptography;

namespace David_Studio_Server.Services
{
    public interface IUserAuthentication
    {
        UserGroup CreateUserGroup(string Role);
        User CreateUser(string login, string password, UserGroup userGroup);
    }

    public class UserAuthentication : IUserAuthentication
    {
        private readonly IConfiguration _configuration;

        public UserAuthentication(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public UserGroup CreateUserGroup(string Role)
        {
            return new UserGroup()
            {
                Role = Role,
            };
        }

        public User CreateUser(string login, string password, UserGroup userGroup)
        {
            string salt = CreateSalt(Convert.ToInt32(_configuration["Authenticate:SaltLength"]));

            return new User()
            {
                Login = login,
                Password = HashPassword(CombinePasswordWithSalt(password, salt)),
                Salt = salt,
                UserGroupId = userGroup.Id
            };
        }
        

        private string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        private string CombinePasswordWithSalt(string password, string salt)
        {
            return password + salt;
        }

        private string HashPassword(string data)
        {
            HashAlgorithm hashAlg = new SHA512CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] byteHash = hashAlg.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
    }
}
