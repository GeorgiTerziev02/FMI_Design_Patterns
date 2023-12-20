using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class DecorateTransformationTests
    {
        [Test]
        public void TransformShouldDefaultDecoratedText()
        {
            // Arrange
            var text = "text";
            var transformation = new DecorateTransformation();
            var expected = "-={ " + text + " }=-";

            // Act
            var actual = transformation.Transform(text);

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
    }
}
