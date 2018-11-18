using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monuments.Manager.Application.Dictionary.Providers.Teryt.Client;
using Monuments.Manager.Application.Dictionary.Providers.Teryt.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt
{
    public static class Registry
    {
        public static IServiceCollection AddTerytDictionaryProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TerytConfigurationOptions>(configuration.GetSection("TerytConfiguration"));
            services.AddScoped<IContractMapper, ContractMapper>();
            services.AddScoped<IWcfClient, WcfClient>();
            services.AddScoped<IWcfClientScopeFactory, WcfClientScopeFactory>();
            services.AddScoped<TerytDictionaryProvider>();

            return services;
        }
    }
}
