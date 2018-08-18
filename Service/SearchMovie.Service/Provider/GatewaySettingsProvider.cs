using SearchMovie.IService.Provider;

namespace SearchMovie.Service.Provider
{
    public class GatewaySettingsProvider : IGatewaySettingsProvider
    {
        public GatewaySettingsProvider(string domain, string apiKey)
        {
            Domain = domain;
            ApiKey = apiKey;
        }

        public string Domain { get; }

        public string ApiKey { get; }
    }
}
