using Microsoft.AspNetCore.Http;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Infrastructure
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MonumentDbContext _monumentsDbContext;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor,
                                     MonumentDbContext monumentsDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _monumentsDbContext = monumentsDbContext;
        }

        public bool Authenticate()
        {
            var userId = int.Parse(_httpContextAccessor.Principal.Identity.Name);
            var user = userService.GetById(userId);
            if (user == null)
            {
                // return unauthorized if user no longer exists
                context.Fail("Unauthorized");
            }
            return Task.CompletedTask;
        }
    }
}
