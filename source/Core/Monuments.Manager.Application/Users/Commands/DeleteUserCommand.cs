using MediatR;
using Monuments.Manager.Application.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Commands
{
    [AdministratorRoleRequirement]
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
