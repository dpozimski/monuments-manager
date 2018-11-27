using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Email
{
    public static class Registry
    {
        public static IServiceCollection AddEmail(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailConfigurationOptions>(configuration.GetSection("EmailConfiguration"));

            services.AddScoped<IEmailSender, EmailSender>();

            return services;
        }
    }
}
