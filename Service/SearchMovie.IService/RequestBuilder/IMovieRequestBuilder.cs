using RestSharp;
using SearchMovie.Model.Search;

namespace SearchMovie.IService.RequestBuilder
{
    public interface IMovieRequestBuilder
    {
        IRestRequest Build(MovieIdModel movieIdModel);
    }
}
