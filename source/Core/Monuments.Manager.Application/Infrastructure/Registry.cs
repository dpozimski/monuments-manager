using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monuments.Manager.Application.Dictionary.Factories;
using Monuments.Manager.Application.Dictionary.Providers.Teryt;
using Monuments.Manager.Application.Email;
using Monuments.Manager.Application.Infrastructure.Encryption;
using Monuments.Manager.Application.Infrastructure.Models;
using Monuments.Manager.Application.Infrastructure.Pipelines;
using Monuments.Manager.Application.Monuments.Commands;
using Monuments.Manager.Common;
using System.Reflection;

namespace Monuments.Manager.Application.Infrastructure
{
    public static class Registry
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationSecurityOptions>(configuration.GetSection("ApplicationSecurity"));
            services.Configure<DictionaryProvidersOptions>(configuration.GetSection("DictionaryProviders"));

            services.AddScoped<IApplicationContext, ApplicationContext>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PerformancePipelineBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuthenticationPipelineBehavior<,>));
            services.AddMediatR(typeof(CreateMonumentCommand).GetTypeInfo().Assembly);

            services.AddTerytDictionaryProvider(configuration);
            services.AddScoped<IDictionaryProviderFactory, DictionaryProviderFactory>();
            services.AddScoped(s => s.GetService<IDictionaryProviderFactory>().Create());

            services.AddScoped<IPasswordEncryptor, Pbkdf2PasswordEncryptor>();
            services.AddScoped<IStringEncoder, PKCS7StringEncoder>();
            services.AddScoped<IPictureFactory, PictureFactory>();

            services.AddEmail(configuration);

            return services;
        }
    }
}
