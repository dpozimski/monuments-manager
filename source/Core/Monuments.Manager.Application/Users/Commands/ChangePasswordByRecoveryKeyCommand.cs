using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Commands
{
    public class ChangePasswordByRecoveryKeyCommand : IRequest
    {
        public string RecoveryKey { get; set; }
        public string Password { get; set; }
    }
}
