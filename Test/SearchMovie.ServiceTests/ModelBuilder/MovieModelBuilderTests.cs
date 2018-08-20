using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchMovie.IService.Provider;
using SearchMovie.IService.RequestBuilder;
using SearchMovie.Model.Request;
using SearchMovie.Model.ResultModel;
using SearchMovie.Model.Search;
using SearchMovie.Service.ModelBuilder;

namespace SearchMovie.UnitTests.ModelBuilder
{
    [TestClass]
    public class MovieModelBuilderTests : BaseAutoMockedTest<MovieModelBuilder>
    {
        [TestMethod]
        public void ShouldBuildSearchResult()
        {
            // Arrange
            var movieId = "1";
            var apikey = "c6788679";
            var movieModel = new MovieIdModel(movieId);
            var searchRequest = new MovieRequest(apikey, movieId);
            var movieResult = Option.Some(new Movie());

            GetMock<IMovieRequestBuilder>()
                .Setup(x => x.Build(movieModel))
                .Returns(searchRequest);

            GetMock<IMovieProvider>()
                .Setup(x => x.Execute(searchRequest))
                .Returns(movieResult);

            // Act
            var result = ClassUnderTest.Build(movieModel);

            // Assert
            Assert.AreEqual(movieResult, result);
        }
    }
}