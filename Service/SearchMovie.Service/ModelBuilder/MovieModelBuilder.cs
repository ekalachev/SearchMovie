using Core;
using SearchMovie.IService.ModelBuilder;
using SearchMovie.IService.Provider;
using SearchMovie.IService.RequestBuilder;
using SearchMovie.Model.ResultModel;
using SearchMovie.Model.Search;

namespace SearchMovie.Service.ModelBuilder
{
    public class MovieModelBuilder : IMovieModelBuilder
    {
        private readonly IMovieRequestBuilder _movieRequestBuilder;
        private readonly IMovieProvider _searchProvider;

        public MovieModelBuilder(
            IMovieRequestBuilder movieRequestBuilder,
            IMovieProvider searchProvider)
        {
            _movieRequestBuilder = movieRequestBuilder;
            _searchProvider = searchProvider;
        }

        public Option<Movie> Build(MovieIdModel movieIdModel)
        {
            // TODO try to get from cache

            var request = _movieRequestBuilder.Build(movieIdModel);

            var movie = _searchProvider.Execute(request);

            return movie;
        }
    }
}
