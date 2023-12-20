using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class ReplaceTransformationTests
    {
        [Test]
        public void TransformShouldReturnsTextWithReplacedCharacters()
        {
            // Arrange
            var expected = "dc";
            var transformation = new ReplaceTransformation("ab", "d");
            var text = "abc";

            // Act
            var actual = transformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
