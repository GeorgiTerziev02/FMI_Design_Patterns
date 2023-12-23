using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class TrimLeftTransformationTests
    {
        private TrimLeftTransformation _transformation;

        [SetUp]
        public void SetUp()
        {
            _transformation = new TrimLeftTransformation();
        }

        [Test]
        public void TransformShouldReturnLeftTrimmedText()
        {
            // Arrange
            var text = "  text  ";
            var expected = "text  ";

            // Act
            var actual = _transformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void EqualsShouldReturnTrueWhenOtherTransformationIsTrimLeftTransformation()
        {
            // Arrange
            var otherTransformation = new TrimLeftTransformation();

            // Act
            var actual = _transformation.Equals(otherTransformation);

            // Assert
            Assert.That(actual, Is.True);
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
        public void EqualsShouldReturnFalseWhenOtherObjectIsNotTrimLeftTransformation()
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
