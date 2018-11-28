using MediatR;
using Monuments.Manager.Application.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Recovery.Commands
{
    [AllowAnonymous]
    public class SendRecoveryKeyCommand : IRequest
    {
        public string Email { get; set; }
    }
}
