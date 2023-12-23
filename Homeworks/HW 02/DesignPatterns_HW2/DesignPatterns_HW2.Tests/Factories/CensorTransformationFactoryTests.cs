using DesignPatterns_HW2.Factories;
using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Factories
{
    [TestFixture]
    public class CensorTransformationFactoryTests
    {
        private const string TO_CENSOR_TEXT = "some text";
        private ICensorTransformationFactory _censorTransformationFactory;

        [SetUp]
        public void SetUp()
        {
            _censorTransformationFactory = new CensorTransformationFactory();
        }

        [Test]
        public void CreateReturnsCensorTransformation()
        {
            // Arrange
            // Act
            var censorTransformation = _censorTransformationFactory.Create(TO_CENSOR_TEXT);

            // Assert
            Assert.That(censorTransformation, Is.InstanceOf<CensorTransformation>());
        }

        [Test]
        public void CreateReturnsSameInstanceForSameTexts()
        {
            // Arrange
            // Act
            var first = _censorTransformationFactory.Create(TO_CENSOR_TEXT);
            var second = _censorTransformationFactory.Create(TO_CENSOR_TEXT);

            // Assert
            Assert.That(first, Is.SameAs(second));
        }

        [Test]
        public void CreateReturnsDifferentInstancesForDifferentTexts()
        {
            // Arrange
            // Act
            var first = _censorTransformationFactory.Create(TO_CENSOR_TEXT);
            var second = _censorTransformationFactory.Create(TO_CENSOR_TEXT + "1");

            // Assert
            Assert.That(first, Is.Not.SameAs(second));
        }
    }
}
