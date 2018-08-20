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
    public class MovieProviderTests : BaseAutoMockedTest<MovieProvider>
    {
        [TestMethod]
        public void ExecuteTest()
        {
            // Arrange
            var movieId = "1";
            var domain = "http://www.omdbapi.com";
            var apikey = "c6788679";
            var movieRequest = new MovieRequest(apikey, movieId);

            var movieGatewaySettingsProvider = GetMock<IGatewaySettingsProvider>();
            movieGatewaySettingsProvider.Setup(x => x.Domain).Returns(domain);
            movieGatewaySettingsProvider.Setup(x => x.ApiKey).Returns(apikey);

            var sResult = new RestResponse<Movie> { Data = new Movie() };

            var mockedRestClient = GetMock<IRestClient>();
            mockedRestClient
                .Setup(x => x.Execute<Movie>(movieRequest))
                .Returns(sResult);

            // Act
            ClassUnderTest.Execute(movieRequest);

            // Assert
            mockedRestClient.Verify(x => x.Execute<Movie>(movieRequest), Times.Once());
        }
    }
}