using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class TrimLeftTransformationTests
    {
        [Test]
        public void TransformShouldReturnLeftTrimmedText()
        {
            // Arrange
            var transformation = new TrimLeftTransformation();
            var text = "  text  ";
            var expected = "text  ";

            // Act
            var actual = transformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
