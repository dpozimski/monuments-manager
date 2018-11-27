using Microsoft.Extensions.Options;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<EmailConfigurationOptions> _emailConfigurationOptions;

        public EmailSender(IOptions<EmailConfigurationOptions> emailConfigurationOptions)
        {
            _emailConfigurationOptions = emailConfigurationOptions;
        }

        public async Task SendRecoveryPasswordMailAsync(string email, string recoveryKey)
        {
            var emailOptions = _emailConfigurationOptions.Value;
            var template = GetTemplate("RecoveryPasswordTemplate");
            var mailContent = template.Replace("#LINK#", $"{emailOptions.RecoveryKeyUrl}{recoveryKey}");

            var mailMessage = new MailMessage(emailOptions.Email, email, "Password recovery", mailContent);

            var client = new SmtpClient();
            client.Host = emailOptions.Host;
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(emailOptions.Email, emailOptions.Password);

            await client.SendMailAsync(mailMessage);
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