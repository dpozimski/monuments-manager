using MediatR;
using Monuments.Manager.Application.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<ICollection<UserDto>>
    {
    }
}
