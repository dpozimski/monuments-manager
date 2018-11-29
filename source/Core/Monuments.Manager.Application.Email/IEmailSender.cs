using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Email
{
    public interface IEmailSender
    {
        Task SendRecoveryPasswordMailAsync(string email, string recoveryKey);
        Task<bool> TrySendWelcomeMailAsync(string email);
    }
}
