using System;
using SearchMovie.IService.Provider;

namespace SearchMovie.Service.Provider
{
    public class GatewaySettingsProvider : IGatewaySettingsProvider
    {
        public GatewaySettingsProvider(string domain, string apiKey)
        {
            Domain = domain ?? throw new ArgumentNullException(nameof(domain));
            ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public string Domain { get; }

        public string ApiKey { get; }
    }
}
