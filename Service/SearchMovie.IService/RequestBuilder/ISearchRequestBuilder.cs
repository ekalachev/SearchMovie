using RestSharp;
using SearchMovie.Model.Search;

namespace SearchMovie.IService.RequestBuilder
{
    public interface ISearchRequestBuilder
    {
        IRestRequest Build(SearchModel searchModel);
    }
}
