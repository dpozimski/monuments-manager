using System.Threading.Tasks;

namespace Monuments.Manager.Application.Email
{
    public interface IEmailSender
    {
        Task SendRecoveryPasswordMailAsync(string email, string recoveryKey);
        Task<bool> TrySendWelcomeMailAsync(string email);
        Task SendPasswordHasBeenChangedByAdministrator(string changedUserEmail, string adminEmail);
    }
}
