using RestSharp;
using SearchMovie.Model.ResultModel;

namespace SearchMovie.IService.Provider
{
    public interface ISearchProvider
    {
        SearchResult Execute(IRestRequest request);
    }
}
