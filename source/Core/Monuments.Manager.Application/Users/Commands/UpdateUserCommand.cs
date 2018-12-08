using MediatR;
using Monuments.Manager.Application.Infrastructure.Models;
using Monuments.Manager.Application.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Commands
{
    [AdministratorRoleRequirement]
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
