using MediatR;
using Monuments.Manager.Application.Infrastructure.Models;
using Monuments.Manager.Application.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Commands
{
    [AllowAnonymous]
    public class AuthenticateUserCommand : IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
