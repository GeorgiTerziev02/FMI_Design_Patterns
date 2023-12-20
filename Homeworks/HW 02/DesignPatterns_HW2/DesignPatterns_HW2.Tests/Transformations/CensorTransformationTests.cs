using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class CensorTransformationTests
    {

        [Test]
        public void Transform_WhenCalled_ReturnsCensoredText()
        {
            // Arrange
            var censorTransformation = new CensorTransformation("World");
            var text = "Hello, World!";
            var expected = "Hello, *****!";

            // Act
            var actual = censorTransformation.Transform(text);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
