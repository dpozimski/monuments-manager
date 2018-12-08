using Microsoft.ApplicationInsights.SnapshotCollector;
using Microsoft.Extensions.Options;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using Microsoft.ApplicationInsights.AspNetCore;

namespace Monuments.Manager.Infrastructure.Debugging
{
    public class SnapshotCollectorTelemetryProcessorFactory : ITelemetryProcessorFactory
    {
        private readonly IOptions<SnapshotCollectorConfiguration> _options;

        public SnapshotCollectorTelemetryProcessorFactory(IOptions<SnapshotCollectorConfiguration> options)
        {
            _options = options;
        }

        public ITelemetryProcessor Create(ITelemetryProcessor next)
        {
            return new SnapshotCollectorTelemetryProcessor(next, configuration: _options.Value);
        }
    }
}
