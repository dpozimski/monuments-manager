using Monuments.Manager.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Models
{
    public class UserDto
    {
        public UserRoleDto Role { get; set; }
        public string Username { get; set; }
    }
}
