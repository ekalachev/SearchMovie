using System;
using RestSharp;
using SearchMovie.IService.Provider;
using SearchMovie.IService.RequestBuilder;
using SearchMovie.Model.Request;
using SearchMovie.Model.Search;

namespace SearchMovie.Service.RequestBuilder
{
    public class MovieRequestBuilder : IMovieRequestBuilder
    {
        private readonly IGatewaySettingsProvider _gatewaySettingsProvider;

        public MovieRequestBuilder(IGatewaySettingsProvider gatewaySettingsProvider)
        {
            _gatewaySettingsProvider = gatewaySettingsProvider ?? throw new ArgumentNullException(nameof(gatewaySettingsProvider));
        }

        public IRestRequest Build(MovieIdModel movieIdModel)
        {
            var request = new MovieRequest(
                _gatewaySettingsProvider.ApiKey,
                movieIdModel.MovieId);

            return request;
        }
    }
}
