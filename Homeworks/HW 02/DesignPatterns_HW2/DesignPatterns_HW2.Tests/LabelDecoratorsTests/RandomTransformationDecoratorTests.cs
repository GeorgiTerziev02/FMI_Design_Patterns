using DesignPatterns_HW2.LabelDecorators;
using DesignPatterns_HW2.Labels;
using DesignPatterns_HW2.Random;
using DesignPatterns_HW2.Tests.Mocks;
using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.LabelDecoratorsTests
{
    [TestFixture]
    public class RandomTransformationDecoratorTests
    {
        private RandomGeneratorMock randomGeneratorMock;
        private RandomTransformationDecorator randomTransformationDecorator;

        [SetUp]
        public void SetUp()
        {
            randomGeneratorMock = new RandomGeneratorMock();
            randomTransformationDecorator = new RandomTransformationDecorator(
                new Label("a"),
                new List<ITextTransformation>()
                {
                    new FirstTransformationMock(),
                    new SecondTransformationMock()
                },
                randomGeneratorMock
            );
        }

        [Test]
        public void GetTextShouldApplyRandomTransformation()
        {
            // Arrange
            randomGeneratorMock.NextReturnValue = 0;

            // Assert
            Assert.That(randomTransformationDecorator.GetText(), Is.EqualTo("First a"));

            // Arrange
            randomGeneratorMock.NextReturnValue = 1;

            // Assert
            Assert.That(randomTransformationDecorator.GetText(), Is.EqualTo("Second a"));
        }
    }
}
