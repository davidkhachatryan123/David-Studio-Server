using System.Security.Cryptography;

namespace David_Studio_Server.Services.Authentication
{
    public interface ICryptography
    {
        string CreateSalt(int size);
        string CombinePasswordWithSalt(string password, string salt);
        string HashPassword(string data);
    }

    public class Cryptography : ICryptography
    {
        public string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        public string CombinePasswordWithSalt(string password, string salt)
        {
            return password + salt;
        }

        public string HashPassword(string data)
        {
            HashAlgorithm hashAlg = new SHA512CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] byteHash = hashAlg.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
    }
}
