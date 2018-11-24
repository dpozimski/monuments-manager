using Monuments.Manager.Application.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monuments.Manager.ViewModels
{
    public class AuthenticateUserResultViewModel
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
