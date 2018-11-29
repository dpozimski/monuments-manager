using Microsoft.Extensions.Options;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace Monuments.Manager.Application.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfigurationOptions _emailOptions;

        public EmailSender(IOptions<EmailConfigurationOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }

        public async Task SendWelcomeMailAsync(string email)
        {
            var template = GetTemplate("WelcomeMessageTemplate");
            var mailContent = template.Replace("#EMAIL#", email);
            await SendMailAsync(email, "Welcome!", mailContent);
        }

        public async Task SendRecoveryPasswordMailAsync(string email, string recoveryKey)
        {
            var template = GetTemplate("RecoveryPasswordTemplate");
            var encodedRecoveryKey = HttpUtility.UrlEncode(recoveryKey);
            var mailContent = template.Replace("#LINK#", $"{_emailOptions.RecoveryKeyUrl}{encodedRecoveryKey}");
            await SendMailAsync(email, "Password recovery", mailContent);
        }

        private async Task SendMailAsync(string to, string subject, string content)
        {
            var message = new MailMessage(_emailOptions.Email, to, subject, content);
            message.IsBodyHtml = true;

            var client = new SmtpClient();
            client.Host = _emailOptions.Host;
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(_emailOptions.Email, _emailOptions.Password);

            await client.SendMailAsync(message);
        }

        private string GetTemplate(string templateName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"Monuments.Manager.Application.Email.Templates.{templateName}.html";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}