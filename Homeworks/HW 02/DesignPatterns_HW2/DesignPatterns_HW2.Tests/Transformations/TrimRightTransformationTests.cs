using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class TrimRightTransformationTests
    {
        private TrimRightTransformation _transformation;

        [SetUp]
        public void SetUp()
        {
            _transformation = new TrimRightTransformation();
        }

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


        [Test]
        public void EqualsShouldReturnTrueWhenOtherTransformationIsTrimRightTransformation()
        {
            // Arrange
            var otherTransformation = new TrimRightTransformation();

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
        public void EqualsShouldReturnFalseWhenOtherObjectIsNotTrimRightTransformation()
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
