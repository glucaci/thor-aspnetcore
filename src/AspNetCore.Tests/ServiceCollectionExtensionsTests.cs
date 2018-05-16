using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Thor.AspNetCore.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        #region AddTracing

        [Fact(DisplayName = "AddTracing: Resolve startup filter")]
        public void AddTracing()
        {
            // arrange
            IServiceCollection services = new ServiceCollection();
            IConfigurationBuilder builder = new ConfigurationBuilder();
            Mock<IApplicationLifetime> appLifetime = new Mock<IApplicationLifetime>();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                {"Tracing:ApplicationId", "5"},
                {"Tracing:Level", "Warning"},
                {"Tracing:EventHub:ConnectionString", "Endpoint=sb://xxx.servicebus.windows.net/;SharedAccessKeyName=Send;SharedAccessKey=67bHkkKw92k/pH6zU7ikSEXxo2oJJ67Kabf5CS4tg367=;EntityPath=rumba"}
            };

            services.AddSingleton(appLifetime.Object);
            builder.AddInMemoryCollection(data);

            IConfiguration configuration = builder.Build();

            // act
            services.AddTracing(configuration);

            // assert
            ServiceProvider provider = services.BuildServiceProvider();

            Assert.IsType<TracingStartupFilter>(provider.GetService<IStartupFilter>());
        }

        #endregion
    }
}