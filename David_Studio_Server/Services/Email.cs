using System.Net.Mail;

namespace David_Studio_Server.Services
{
    public interface IEmail
    {
        bool SendEmail(string to, string message);
    }

    public class Email : IEmail
    {
        private readonly ILogger<Email> _logger;

        public Email(ILogger<Email> logger)
        {
            _logger = logger;
        }

        public bool SendEmail(string to, string message)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("xdavit7@gmail.com");
            mailMessage.To.Add(new MailAddress(to));

            mailMessage.Subject = "Two Factor Code";
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
    }
}
