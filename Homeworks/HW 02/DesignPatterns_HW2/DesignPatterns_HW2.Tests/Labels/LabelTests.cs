using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Tests.Labels
{
    [TestFixture]
    public class LabelTests
    {
        [Test]
        public void GetTextShouldReturnCorrectly()
        {
            // Arrange
            var expectedText = "test";
            var label = new Label(expectedText);

            // Act
            var actualText = label.GetText();

            // Assert
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
    }
}
