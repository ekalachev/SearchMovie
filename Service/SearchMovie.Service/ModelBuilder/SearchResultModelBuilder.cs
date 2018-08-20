using System;
using Core;
using SearchMovie.IService.ModelBuilder;
using SearchMovie.IService.Provider;
using SearchMovie.IService.RequestBuilder;
using SearchMovie.Model.ResultModel;
using SearchMovie.Model.Search;

namespace SearchMovie.Service.ModelBuilder
{
    public class SearchResultModelBuilder : ISearchResultModelBuilder
    {
        private readonly ISearchRequestBuilder _searchRequestBuilder;
        private readonly ISearchProvider _searchProvider;

        public SearchResultModelBuilder(
            ISearchRequestBuilder searchRequestBuilder,
            ISearchProvider searchProvider)
        {
            _searchRequestBuilder = searchRequestBuilder ?? throw new ArgumentNullException(nameof(searchRequestBuilder));
            _searchProvider = searchProvider ?? throw new ArgumentNullException(nameof(searchProvider));
        }

        public Option<SearchResult> Build(SearchModel searchModel)
        {
            // TODO try to get from cache

            var request = _searchRequestBuilder.Build(searchModel);

            var searchResult = _searchProvider.Execute(request);

            return searchResult;
        }
    }
}
