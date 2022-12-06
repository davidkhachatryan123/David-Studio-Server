using David_Studio_Server.Controllers.Admin.Auth;
using David_Studio_Server.Models.Dashboard.Users;
using David_Studio_Server.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using David_Studio_Server.Database.Models.Authentication;

namespace David_Studio_Server.Services
{
    public interface IEmail
    {
        bool SendEmail(string to, string subject, string message);

        Task<bool> SendConfirmEmailAsync(ApplicationUser user, string confirmationLink);

        string GetEmailConfirmationPage(string confirmationLink);
        string RedirectToLogin(string loginUrl);

        string Get2FAEmailBody(string token);
    }

    public class Email : IEmail
    {
        private readonly ILogger<Email> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public Email(
            ILogger<Email> logger,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
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

        public async Task<bool> SendConfirmEmailAsync(ApplicationUser user, string confirmationLink)
        {
            var emailBody = GetEmailConfirmationPage(confirmationLink!);

            bool emailResponse = SendEmail(user.Email, "David Studio - Email Confirmation", emailBody);

            return emailResponse;
        }

        public string GetEmailConfirmationPage(string confirmationLink)
        {
            var content = System.IO.File.ReadAllText(@"assets/EmailConfirm.html");
            content = content.Replace("{{link}}", confirmationLink);

            return content;
        }

        public string RedirectToLogin(string loginUrl)
        {
            var content = System.IO.File.ReadAllText(@"assets/RedirectToLogin.html");
            content = content.Replace("{{url}}", loginUrl);

            return content;
        }

        public string Get2FAEmailBody(string token)
        {
            var content = System.IO.File.ReadAllText(@"assets/2FACode.html");
            content = content.Replace("{{token}}", token.Insert(3, " - "));
            return content;
        }
    }
}
