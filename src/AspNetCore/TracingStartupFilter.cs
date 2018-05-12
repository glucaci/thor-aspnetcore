using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Thor.AspNetCore
{
    /// <summary>
    /// A <see cref="IStartupFilter"/> to initialize tracing.
    /// </summary>
    public class TracingStartupFilter
        : IStartupFilter
    {
        /// <inheritdoc />
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder
                    .ApplicationServices
                    .GetService<DiagnosticsListenerInitializer>()
                    .Start();

                next(builder);
            };
        }
    }
}