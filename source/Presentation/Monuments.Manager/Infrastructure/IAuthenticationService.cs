using Monuments.Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monuments.Manager.Infrastructure
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(AuthenticateUserViewModel viewModel);
    }
}
