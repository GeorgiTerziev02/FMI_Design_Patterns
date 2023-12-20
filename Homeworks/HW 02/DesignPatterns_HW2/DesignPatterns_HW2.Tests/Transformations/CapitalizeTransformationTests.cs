using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class CapitalizeTransformationTests
    {
        private CapitalizeTransformation _transformation;

        [SetUp]
        public void Setup()
        {
            _transformation = new CapitalizeTransformation();
        }

        [Test]
        public void TransformShouldReturnTextWithFirstCapitalLetter()
        {
            // Arrange
            var text = "hello world";
            var expected = "Hello world";

            // Act
            var actual = _transformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("   ")]
        public void TransformShouldReturnEmptyStringWhenTextIsEmpty(string text)
        {
            // Arrange
            var expected = string.Empty;

            // Act
            var actual = _transformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
