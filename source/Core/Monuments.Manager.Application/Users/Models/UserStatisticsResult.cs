using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Users.Models
{
    public class UserStatisticsResult
    {
        public DateTime LastLoggedIn { get; set; }
        public int CreatedMonuments { get; set; }
        public string LastModifiedMonument { get; set; }
        public UserRoleDto Role { get; set; }
    }
}
