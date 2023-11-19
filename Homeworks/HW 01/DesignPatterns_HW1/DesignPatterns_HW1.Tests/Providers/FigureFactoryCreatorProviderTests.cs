using DesignPatterns_HW1.Creators;
using DesignPatterns_HW1.Providers;

namespace DesignPatterns_HW1.Tests.Providers
{
    [TestFixture]
    public class FigureFactoryCreatorProviderTests
    {
        [Test]
        public void CreateShouldCreateCorrectly()
        {
            // arrange
            IFigureFactoryCreatorProvider provider = new FigureFactoryCreatorProvider();

            // act
            var figureFactoryCreator = provider.GetFigureFactoryCreator();

            // assert
            Assert.That(figureFactoryCreator, Is.InstanceOf<FigureFactoryCreator>());
        }
    }
}
