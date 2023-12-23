using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class ReplaceTransformationTests
    {
        private ReplaceTransformation _transformation;

        [SetUp]
        public void SetUp()
        {
            _transformation = new ReplaceTransformation("ab", "d");    
        }

        [Test]
        public void TransformShouldReturnsTextWithReplacedCharacters()
        {
            // Arrange
            var expected = "dc";
            var text = "abc";

            // Act
            var actual = _transformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void EqualsShouldReturnTrueWhenOtherTransformationHasSameReplaceWords()
        {
            // Arrange
            var otherTransformation = new ReplaceTransformation("ab", "d");

            // Act
            var actual = _transformation.Equals(otherTransformation);

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenOtherTransformationHasDifferentReplaceWords()
        {
            // Arrange
            var otherTransformation = new ReplaceTransformation("ab", "c");

            // Act
            var actual = _transformation.Equals(otherTransformation);

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenOtherTransformationIsNull()
        {
            // Arrange
            // Act
            var actual = _transformation.Equals(null);

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenOtherObjectIsNotReplaceTransformation()
        {
            // Arrange
            var otherObj = new object();

            // Act
            var actual = _transformation.Equals(otherObj);

            // Assert
            Assert.That(actual, Is.False);
        }
    }
}
