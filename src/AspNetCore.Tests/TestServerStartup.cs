using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Thor.AspNetCore.Tests
{
    public class TestServerStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTracing();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}