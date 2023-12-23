using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Tests.Labels
{
    [TestFixture]
    public class RichLabelTests
    {
        [Test]
        public void GetTextShouldReturnCorrectly()
        {
            // Arrange
            var expectedText = "test";
            var expectedColor = "red";
            var expectedFont = "Arial";
            var expectedFontSize = 16;
            var label = new RichLabel(expectedText, expectedColor, expectedFontSize, expectedFont);

            // Act
            var actualText = label.GetText();

            // Assert
            Assert.That(actualText, Contains.Substring(expectedText));
            Assert.That(actualText, Contains.Substring(expectedFont));
            Assert.That(actualText, Contains.Substring(expectedFontSize.ToString()));
            Assert.That(actualText, Contains.Substring(expectedColor));
        }
    }
}
