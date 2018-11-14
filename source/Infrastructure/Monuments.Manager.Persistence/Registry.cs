using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence
{
    public static class Registry
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MonumentsDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("MonumentsDatabase")));

            services.AddScoped<IConfigurationBuilder, ConfigurationBuilder>();
            services.AddScoped<IDateTimeProvider, SystemDateTimeProvider>();

            return services;
        }
    }
}
