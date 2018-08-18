using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchMovie.Model.ResultModel;
using SearchMovie.UI.Wrapper;

namespace SearchMovie.UnitTests.Wrapper
{
    [TestClass]
    public class MovieShortWrapperTests
    {
        private MovieShort _movieShort;

        [TestInitialize]
        public void Startup()
        {
            _movieShort = new MovieShort
            {
                ImdbID = "1",
                Title = "air",
                Year = "2000",
                Type = "movie",
                Poster = "poster"
            };
        }

        [TestMethod]
        public void ShouldContainModelInModelProperty()
        {
            // Arrange // Act
            var wrapper = new MovieShortWrapper(_movieShort);

            // Assert
            Assert.AreEqual(_movieShort, wrapper.Model);
        }

        [TestMethod]
        public void ShouldThrowArgumentNullExceptionIfModelIsNull()
        {
            // Arrange // Act // Assert
            Assert.ThrowsException<ArgumentNullException>(() => 
                new MovieShortWrapper(null));
        }

        [TestMethod]
        public void ShouldGetValueOfUnderlyingModelProperty()
        {
            // Arrange // Act
            var wrapper = new MovieShortWrapper(_movieShort);

            // Assert
            Assert.AreEqual(_movieShort.ImdbID, wrapper.Id);
            Assert.AreEqual(_movieShort.Title, wrapper.Title);
            Assert.AreEqual(_movieShort.Type, wrapper.Type);
            Assert.AreEqual(_movieShort.Poster, wrapper.Poster);
            Assert.AreEqual(_movieShort.Year, wrapper.Year);
        }
    }
}