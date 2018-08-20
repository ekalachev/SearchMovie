using System;
using RestSharp;
using SearchMovie.IService.Provider;
using SearchMovie.IService.RequestBuilder;
using SearchMovie.Model.Request;
using SearchMovie.Model.Search;

namespace SearchMovie.Service.RequestBuilder
{
    public class SearchRequestBuilder : ISearchRequestBuilder
    {
        private readonly IGatewaySettingsProvider _gatewaySettingsProvider;

        public SearchRequestBuilder(IGatewaySettingsProvider gatewaySettingsProvider)
        {
            _gatewaySettingsProvider = gatewaySettingsProvider ?? throw new ArgumentNullException(nameof(gatewaySettingsProvider));
        }

        public IRestRequest Build(SearchModel searchModel)
        {
            var request = new SearchRequest(
                _gatewaySettingsProvider.ApiKey,
                searchModel.FilmTitle);

            return request;
        }
    }
}
