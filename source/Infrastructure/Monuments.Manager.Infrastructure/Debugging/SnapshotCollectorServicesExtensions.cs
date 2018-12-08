using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.ApplicationInsights.SnapshotCollector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Monuments.Manager.Infrastructure.Debugging
{
    public static class SnapshotCollectorServicesExtensions
    {
        public static IServiceCollection AddSnapshotCollectorService(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection(nameof(SnapshotCollectorConfiguration));
            services.Configure<SnapshotCollectorConfiguration>(config);
            services.AddSingleton<ITelemetryProcessorFactory, SnapshotCollectorTelemetryProcessorFactory>();

            return services;
        }
    }
}
