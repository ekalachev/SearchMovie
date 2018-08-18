using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using SearchMovie.IService.Provider;
using SearchMovie.Model.Request;
using SearchMovie.Model.ResultModel;
using SearchMovie.Service.Provider;

namespace SearchMovie.UnitTests.Provider
{
    [TestClass]
    public class SearchProviderTests : BaseAutoMockedTest<SearchProvider>
    {
        [TestMethod]
        public void ExecuteTest()
        {
            // Arrange
            var filmTitle = "air";
            var domain = "http://www.omdbapi.com";
            var apikey = "c6788679";
            var searchRequest = new SearchRequest(apikey, filmTitle);

            var movieGatewaySettingsProvider = GetMock<IGatewaySettingsProvider>();
            movieGatewaySettingsProvider.Setup(x => x.Domain).Returns(domain);
            movieGatewaySettingsProvider.Setup(x => x.ApiKey).Returns(apikey);

            var sResult = new RestResponse<SearchResult> { Data = new SearchResult() };

            var mockedRestClient = GetMock<IRestClient>();
            mockedRestClient
                .Setup(x => x.Execute<SearchResult>(searchRequest))
                .Returns(sResult);

            // Act
            ClassUnderTest.Execute(searchRequest);

            // Assert
            mockedRestClient.Verify(x => x.Execute<SearchResult>(searchRequest), Times.Once());
        }
    }
}