using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Thor.Core.Abstractions;
using Thor.Core.Session;

namespace Thor.AspNetCore
{
    /// <summary>
    /// A bunch of convenient extensions methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <c>Thor Tracing</c> services to the service collection.
        /// </summary>
        /// <param name="services">A <see cref="IServiceCollection"/> instance.</param>
        /// <returns>The provided <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddTracing(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddOptions()
                .Configure<TracingStartupConfiguration>(c => { })
                .AddSingleton(p => p.GetService<IOptions<TracingStartupConfiguration>>().Value)
                .AddSingleton<ITelemetrySession>(p =>
                {
                    TracingStartupConfiguration configuration = p.GetService<TracingStartupConfiguration>();

                    return InProcessTelemetrySession.Create(configuration.ApplicationId);
                })
                .AddSingleton<IDiagnosticsListener, HostingDiagnosticsListener>()
                .AddSingleton<DiagnosticsListenerInitializer>()
                .AddSingleton<IStartupFilter, TracingStartupFilter>();
        }
    }
}