using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class TrimRightTransformationTests
    {
        [Test]
        public void TransformShouldReturnRightTrimmedText()
        {
            // Arrange
            var transformation = new TrimRightTransformation();
            var text = "  text  ";
            var expected = "  text";

            // Act
            var actual = transformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
