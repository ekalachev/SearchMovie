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
    public class SearchResultModelBuilderTests : BaseAutoMockedTest<SearchResultModelBuilder>
    {
        [TestMethod]
        public void ShouldBuildSearchResult()
        {
            // Arrange
            var filmTitle = "air";
            var apikey = "c6788679";
            var searchModel = new SearchModel(filmTitle);
            var searchRequest = new SearchRequest(apikey, filmTitle);
            var searchResult = Option.Some(new SearchResult());

            GetMock<ISearchRequestBuilder>()
                .Setup(x => x.Build(searchModel))
                .Returns(searchRequest);

            GetMock<ISearchProvider>()
                .Setup(x => x.Execute(searchRequest))
                .Returns(searchResult);

            // Act
            var result = ClassUnderTest.Build(searchModel);

            // Assert
            Assert.AreEqual(searchResult, result);
        }
    }
}