using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchMovie.IService.Provider;
using SearchMovie.Model.Search;
using SearchMovie.Service.RequestBuilder;

namespace SearchMovie.UnitTests.RequestBuilder
{
    [TestClass]
    public class SearchRequestBuilderTests : BaseAutoMockedTest<SearchRequestBuilder>
    {
        [TestMethod]
        public void ShouldReturnValidRequest()
        {
            // Arrange
            var filmTitle = "air";
            var searchModel = new SearchModel(filmTitle);
            var domain = "http://www.omdbapi.com";
            var apikey = "c6788679";

            var movieGatewaySettingsProvider = GetMock<IGatewaySettingsProvider>();
            movieGatewaySettingsProvider.Setup(x => x.Domain).Returns(domain);
            movieGatewaySettingsProvider.Setup(x => x.ApiKey).Returns(apikey);

            // Act
            var request = ClassUnderTest.Build(searchModel);

            // Assert
            Assert.AreEqual(
                apikey,
                request.Parameters.Where(x => x.Name == "apikey").Select(x => x.Value).FirstOrDefault()
            );

            Assert.AreEqual(
                filmTitle,
                request.Parameters.Where(x => x.Name == "s").Select(x => x.Value).FirstOrDefault()
            );
        }
    }
}