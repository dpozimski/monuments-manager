using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Commands
{
    public class PromoteUserCommand : IRequest
    {
        public string Email { get; set; }
    }
}
