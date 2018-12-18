using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monuments.Manager.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence
{
    public static class Registry
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AddressConfiguration>();
            services.AddScoped<MonumentConfiguration>();
            services.AddScoped<PictureConfiguration>();
            services.AddScoped<UserConfiguration>();

            services.AddDbContext<MonumentsDbContext>(options =>
                options.UseLazyLoadingProxies()
                       .UseSqlServer(configuration.GetConnectionString("MonumentsDatabase")));

            services.AddScoped<IConfigurationBuilder, ConfigurationBuilder>();
            services.AddScoped<IEntityChangedDateHook, EntityChangedDateHook>();
            services.AddScoped<IEntityChangedUserContextHook, EntityChangedUserContextHook>();

            return services;
        }
    }
}
