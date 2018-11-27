using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Commands
{
    public class SendRecoveryKeyCommand : IRequest
    {
        public string Username { get; set; }
    }
}
