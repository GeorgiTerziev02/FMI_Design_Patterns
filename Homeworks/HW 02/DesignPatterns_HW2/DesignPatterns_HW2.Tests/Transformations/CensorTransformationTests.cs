using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class CensorTransformationTests
    {
        private readonly string CENSOR_TEXT = "World";
        private ITextTransformation _transformation;

        [SetUp]
        public void SetUp()
        {
            _transformation = new CensorTransformation(CENSOR_TEXT);
        }

        [Test]
        public void Transform_WhenCalled_ReturnsCensoredText()
        {
            // Arrange
            var text = $"Hello, {CENSOR_TEXT}!";
            var expected = "Hello, *****!";

            // Act
            var actual = _transformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void EqualsShouldReturnTrueWhenOtherTransformationHasSameCensorWord()
        {
            // Arrange
            var otherTransformation = new CensorTransformation(CENSOR_TEXT);

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
        public void EqualsShouldReturnFalseWhenOtherObjectIsNotCensorTransformation()
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
