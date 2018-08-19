using Core;
using SearchMovie.Model.ResultModel;
using SearchMovie.Model.Search;

namespace SearchMovie.IService.ModelBuilder
{
    public interface IMovieModelBuilder
    {
        Option<Movie> Build(MovieIdModel movieIdModel);
    }
}
