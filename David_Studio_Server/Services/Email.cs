using System.Net.Mail;
using System.Text;

namespace David_Studio_Server.Services
{
    public interface IEmail
    {
        bool SendEmail(string to, string subject, string message);

        string GetEmailConfirmationPage(string confirmationLink);
        string RedirectToLogin(string loginUrl);

        string Get2FAEmailBody(string token);
    }

    public class Email : IEmail
    {
        private readonly ILogger<Email> _logger;

        public Email(ILogger<Email> logger)
        {
            _logger = logger;
        }

        public bool SendEmail(string to, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("xdavit7@gmail.com");
            mailMessage.To.Add(new MailAddress(to));

            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = message;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("xdavit7@gmail.com", "yeezjutshaljwowu");

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Cannot send Email to Address: {0}\nException Message: {ex.Message}", to);
            }
            return false;
        }

        public string GetEmailConfirmationPage(string confirmationLink)
        {
            var content = File.ReadAllText(@"assets/EmailConfirm.html");
            content = content.Replace("{{link}}", confirmationLink);

            return content;
        }

        public string RedirectToLogin(string loginUrl)
        {
            var content = File.ReadAllText(@"assets/RedirectToLogin.html");
            content = content.Replace("{{url}}", loginUrl);

            return content;
        }

        public string Get2FAEmailBody(string token)
        {
            var content = File.ReadAllText(@"assets/2FACode.html");
            content = content.Replace("{{token}}", token.Insert(3, " - "));

            return content;
        }
    }
}
