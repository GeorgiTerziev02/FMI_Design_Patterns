using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Transformations
{
    [TestFixture]
    public class CompositeTextTransformationTests
    {
        [Test]
        public void Transform_WithTwoTransformations_ReturnsCorrectResult()
        {
            // Arrange
            var expected = "Hello World!";
            var transformation = new CompositeTextTransformation
            (
                new List<ITextTransformation>
                {
                    new TrimLeftTransformation(),
                    new TrimRightTransformation(),
                    new CapitalizeTransformation()
                }
            );

            // Act
            var actual = transformation.Transform("  hello World!  ");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
