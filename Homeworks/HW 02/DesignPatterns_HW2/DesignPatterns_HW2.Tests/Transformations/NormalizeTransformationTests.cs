using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class NormalizeTransformationTests
    {
        private NormalizeTransformation _normalizeTransformation;

        [SetUp]
        public void SetUp()
        {
            _normalizeTransformation = new NormalizeTransformation();
        }

        [Test]
        public void TransformShouldNormalizedText()
        {
            // Arrange
            var expected = "Hello World!";
            var text = "   Hello   World!   ";

            // Act
            var actual = _normalizeTransformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
