using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class DecorateTransformationTests
    {
        private DecorateTransformation _transformation;

        [SetUp]
        public void SetUp()
        {
            _transformation = new DecorateTransformation();
        }

        [Test]
        public void TransformShouldDefaultDecoratedText()
        {
            // Arrange
            var text = "text";
            var expected = "-={ " + text + " }=-";

            // Act
            var actual = _transformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TransformShouldDecorateTextWithCustomDecoration()
        {
            // Arrange
            var text = "text";
            var prefixDecoration = "prefix";
            var postfixDecoration = "postfix";
            var transformation = new DecorateTransformation(prefixDecoration, postfixDecoration);
            var expected = prefixDecoration + " " + text + " " + postfixDecoration;

            // Act
            var actual = transformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void EqualsShouldReturnTrueWhenOtherTransformationHasSameDecorations()
        {
            // Arrange
            var otherTransformation = new DecorateTransformation();

            // Act
            var actual = _transformation.Equals(otherTransformation);

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenOtherTransformationHasDifferentDecorations()
        {
            // Arrange
            var otherTransformation = new DecorateTransformation("prefix", "postfix");

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
        public void EqualsShouldReturnFalseWhenOtherObjectIsNotDecorateTransformation()
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
