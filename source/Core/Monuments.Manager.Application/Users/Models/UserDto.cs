using Monuments.Manager.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRoleDto Role { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
    }
}
