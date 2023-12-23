using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class CompositeTextTransformationTests
    {
        private CompositeTextTransformation _transformation;

        private CompositeTextTransformation CreateCompositeTransformation()
        {
            return new CompositeTextTransformation
            (
                new List<ITextTransformation>
                {
                    new TrimLeftTransformation(),
                    new TrimRightTransformation(),
                    new CapitalizeTransformation()
                }
            );
        }

        [SetUp]
        public void SetUp()
        {
            _transformation = CreateCompositeTransformation();
        }

        [Test]
        public void Transform_WithTwoTransformations_ReturnsCorrectResult()
        {
            // Arrange
            var expected = "Hello World!";

            // Act
            var actual = _transformation.Transform("  hello World!  ");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void EqualsShouldReturnTrueWhenOtherTransformationIsSameTransformation()
        {
            // Arrange
            var otherTransformation = CreateCompositeTransformation();

            // Act
            var actual = _transformation.Equals(otherTransformation);

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenOtherTransformationHasDifferentTransformationsCount()
        {
            // Arrange
            var otherTransformation = new CompositeTextTransformation
            (
                new List<ITextTransformation>
                {
                    new TrimLeftTransformation(),
                }
            );

            // Act
            var actual = _transformation.Equals(otherTransformation);

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenOtherTransformationHasDifferentTransformations()
        {
            // Arrange
            var otherTransformation = new CompositeTextTransformation
            (
                new List<ITextTransformation>
                {
                    new TrimLeftTransformation(),
                    new TrimRightTransformation(),
                    new DecorateTransformation()
                }
            );

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
        public void EqualsShouldReturnFalseWhenOtherObjectIsNotCapitalizeTransformation()
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
