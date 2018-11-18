using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monuments.Manager.Common;
using Monuments.Manager.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Infrastructure
{
    public static class Registry
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwtAuthentication(configuration);
            services.AddScoped<IDateTimeProvider, SystemDateTimeProvider>();

            return services;
        }
    }
}
