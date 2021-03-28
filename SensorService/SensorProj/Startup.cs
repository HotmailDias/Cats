using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Sensor.Config;
using System.Diagnostics.CodeAnalysis;
using Sensor.Services;

[assembly: FunctionsStartup(typeof(Sensor.Startup))]
namespace Sensor
{
    public class Startup : FunctionsStartup
    {
        [ExcludeFromCodeCoverage]
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            builder.Services.AddSingleton<IConfiguration>(config);

            builder.Services.AddSingleton<IConfigSettings, ConfigSettings>();
            builder.Services.AddSingleton<IApiService, ApiService>();
        }
    }
}
