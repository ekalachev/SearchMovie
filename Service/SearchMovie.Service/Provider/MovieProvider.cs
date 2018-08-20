using System;
using Core;
using RestSharp;
using SearchMovie.IService.Provider;
using SearchMovie.Model.ResultModel;

namespace SearchMovie.Service.Provider
{
    public class MovieProvider : IMovieProvider
    {
        private readonly IRestClient _restClient;
        private readonly IGatewaySettingsProvider _gatewaySettingsProvider;

        public MovieProvider(
            IRestClient restClient,
            IGatewaySettingsProvider gatewaySettingsProvider)
        {
            _restClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
            _gatewaySettingsProvider = gatewaySettingsProvider ?? throw new ArgumentNullException(nameof(gatewaySettingsProvider));
        }

        public Option<Movie> Execute(IRestRequest request)
        {
            _restClient.BaseUrl = new Uri(_gatewaySettingsProvider.Domain);

            var result = _restClient.Execute<Movie>(request);

            return result.Data != null
                ? Option.Some(result.Data)
                : Option.None<Movie>();
        }
    }
}
