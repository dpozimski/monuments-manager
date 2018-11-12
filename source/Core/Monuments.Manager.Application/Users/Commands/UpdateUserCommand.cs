using MediatR;
using Monuments.Manager.Application.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public UserRoleDto Role { get; set; }
        public string JobTitle { get; set; }
    }
}
