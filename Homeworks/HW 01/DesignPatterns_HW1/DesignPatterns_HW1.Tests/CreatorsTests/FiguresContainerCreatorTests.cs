using DesignPatterns_HW1.Creators;

namespace DesignPatterns_HW1.Tests.CreatorsTests
{
    [TestFixture]
    public class FiguresContainerCreatorTests
    {
        [Test]
        public void CreateShouldCreateCorrectly()
        {
            // arrange
            // act
            var figuresContainer = FiguresContainerCreator.Create(10);

            // assert
            Assert.That(figuresContainer, Is.InstanceOf<FiguresContainer.FiguresContainer>());
        }
    }
}
