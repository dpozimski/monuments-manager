using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
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
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IOptions<EmailConfigurationOptions> emailOptions,
                           ILogger<EmailSender> logger)
        {
            _emailOptions = emailOptions.Value;
            _logger = logger;
        }

        public async Task<bool> TrySendWelcomeMailAsync(string email)
        {
            var template = GetTemplate("WelcomeMessageTemplate");
            var mailContent = template.Replace("#EMAIL#", email);

            try
            {
                await SendMailAsync(email, "Welcome!", mailContent);

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, "Cannot send email");

                return false;
            }
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
            var message = new MailMessage(_emailOptions.Email, to, subject, content)
            {
                IsBodyHtml = true
            };

            var client = new SmtpClient
            {
                Host = _emailOptions.Host,
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Credentials = new NetworkCredential(_emailOptions.Email, _emailOptions.Password)
            };

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