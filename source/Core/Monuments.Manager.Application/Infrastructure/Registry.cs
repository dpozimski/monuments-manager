using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monuments.Manager.Application.Dictionary.Factories;
using Monuments.Manager.Application.Dictionary.Providers.Teryt;
using Monuments.Manager.Application.Infrastructure.Models;
using Monuments.Manager.Application.Infrastructure.Pipelines;
using Monuments.Manager.Application.Monuments.Commands;
using System.Reflection;

namespace Monuments.Manager.Application.Infrastructure
{
    public static class Registry
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationSecurityOptions>(configuration.GetSection("ApplicationSecurity"));
            services.Configure<DictionaryProvidersOptions>(configuration.GetSection("DictionaryProviders"));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PerformancePipelineBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuthenticationPipelineBehavior<,>));
            services.AddMediatR(typeof(CreateMonumentCommand).GetTypeInfo().Assembly);

            services.AddTerytDictionaryProvider(configuration);
            services.AddScoped<IDictionaryProviderFactory, DictionaryProviderFactory>();
            services.AddScoped(s => s.GetService<IDictionaryProviderFactory>().Create());

            return services;
        }
    }
}
