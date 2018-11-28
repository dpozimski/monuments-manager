using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Recovery.Commands
{
    public class SendRecoveryKeyCommand : IRequest
    {
        public string Email { get; set; }
    }
}
