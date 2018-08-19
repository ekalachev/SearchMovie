using Core;
using RestSharp;
using SearchMovie.Model.ResultModel;

namespace SearchMovie.IService.Provider
{
    public interface IMovieProvider
    {
        Option<Movie> Execute(IRestRequest request);
    }
}
