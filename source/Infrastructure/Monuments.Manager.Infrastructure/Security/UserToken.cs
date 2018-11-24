using Monuments.Manager.Application.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Infrastructure.Security
{
    public class UserToken
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
