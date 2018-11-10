using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Infrastructure
{
    public interface IAuthenticationService
    {
        bool Authenticate();
    }
}
