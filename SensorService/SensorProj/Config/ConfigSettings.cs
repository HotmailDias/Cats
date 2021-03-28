using Microsoft.Extensions.Configuration;

namespace Sensor.Config
{
    public class ConfigSettings : IConfigSettings
    {
        public string ApiUrl => _config.GetValue<string>("ApiUrl");

        public int RetryAttempts => 3;

        public int WaitInterval => 2000;

        public IConfiguration _config;

        public ConfigSettings(IConfiguration config)
        {
            this._config = config;
        }
    }

    public interface IConfigSettings
    {
        string ApiUrl { get; }

        int RetryAttempts { get; }

        int WaitInterval { get; }
    }
}
