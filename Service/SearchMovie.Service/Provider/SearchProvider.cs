using System;
using RestSharp;
using SearchMovie.IService.Provider;
using SearchMovie.Model.ResultModel;

namespace SearchMovie.Service.Provider
{
    public class SearchProvider : ISearchProvider
    {
        private readonly IRestClient _restClient;
        private readonly IGatewaySettingsProvider _gatewaySettingsProvider;

        public SearchProvider(
            IRestClient restClient,
            IGatewaySettingsProvider gatewaySettingsProvider)
        {
            _restClient = restClient;
            _gatewaySettingsProvider = gatewaySettingsProvider;
        }

        public SearchResult Execute(IRestRequest request)
        {
            _restClient.BaseUrl = new Uri(_gatewaySettingsProvider.Domain);

            var result = _restClient.Execute<SearchResult>(request);

            return result.Data;
        }
    }
}
