using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Tests.Labels
{
    [TestFixture]
    public class HelpLabelTests
    {
        private const string TEXT = "test";
        private const string HELP_TEXT = "help";

        [Test]
        public void GetHelpTextShouldReturnCorrectly()
        {
            // Arrange
            var helpLabel = new HelpLabel
            (
                new Label(TEXT),
                new Label(HELP_TEXT)
            );

            // Act
            var actualText = helpLabel.GetHelpText();

            // Assert
            Assert.That(actualText, Is.EqualTo(HELP_TEXT));
        }

        [Test]
        public void GetTextShouldReturnCorrectly()
        {
            // Arrange
            var helpLabel = new HelpLabel
            (
                new Label(TEXT),
                new Label(HELP_TEXT)
            );

            // Act
            var actualText = helpLabel.GetText();

            // Assert
            Assert.That(actualText, Is.EqualTo(TEXT));
        }
    }
}
