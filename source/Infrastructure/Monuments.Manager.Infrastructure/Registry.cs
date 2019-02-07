using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Monuments.Manager.Common;
using Monuments.Manager.Infrastructure.Debugging;
using Monuments.Manager.Infrastructure.Security;
using System.Linq;

namespace Monuments.Manager.Infrastructure
{
    public static class Registry
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
                ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });
            services.AddSnapshotCollectorService(configuration);
            services.AddJwtAuthentication(configuration);
            services.AddScoped<IDateTimeProvider, SystemDateTimeProvider>();
            services.AddScoped<ExceptionHandlingMiddleware>();

            return services;
        }

        public static ILoggingBuilder AddInfrastructureLogging(this ILoggingBuilder logging, WebHostBuilderContext hostingContext)
        {
            logging.AddApplicationInsights();
            logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            logging.AddConsole();
            logging.AddDebug();

            return logging;
        }
    }
}
