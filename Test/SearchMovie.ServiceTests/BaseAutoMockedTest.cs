using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StructureMap.AutoMocking.Moq;

namespace SearchMovie.UnitTests
{
    public class BaseAutoMockedTest<T> where T : class 
    {
        public virtual T ClassUnderTest => Mocker.ClassUnderTest;

        public MoqAutoMocker<T> Mocker { get; set; }

        [TestInitialize]
        public void Startup()
        {
            Mocker = CreateAutoMocker();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Mocker = null;
        }

        protected virtual MoqAutoMocker<T> CreateAutoMocker()
        {
            return new MoqAutoMocker<T>();
        }

        protected Mock<TDepend> GetMock<TDepend>()
            where TDepend : class
        {
            var depend = Mocker.Get<TDepend>();
            try
            {
                return Mock.Get(depend);
            }
            catch (ArgumentException)
            {
                var dependMock = new Mock<TDepend>();
                Mocker.Inject(dependMock.Object);
                return dependMock;
            }
        }
    }
}
