using DesignPatterns_HW2.Factories;
using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Tests.Factories
{
    [TestFixture]
    public class LabelFactoryTests
    {
        private const string LABEL_TEXT = "some text";
        private ILabelFactory _labelFactory;

        [SetUp]
        public void SetUp()
        {
            _labelFactory = new LabelFactory();
        }

        [Test]
        public void CreateLabelReturnsLabel()
        {
            // Arrange
            // Act
            var label = _labelFactory.CreateLabel(LABEL_TEXT);

            // Assert
            Assert.That(label, Is.InstanceOf<Label>());
            Assert.That(label.GetText(), Is.EqualTo(LABEL_TEXT));
        }

        [Test]
        public void CreateHelpLabelReturnsHelpLabel()
        {
            // Arrange
            const string HELP_TEXT = "help text";
            var label1 = new Label(LABEL_TEXT);
            var label2 = new Label(HELP_TEXT);

            // Act
            var label = _labelFactory.CreateHelpLabel(label1, label2);

            // Assert
            Assert.That(label, Is.InstanceOf<HelpLabel>());
            Assert.That(label.GetText(), Is.EqualTo(LABEL_TEXT));
            var helpLabel = label as HelpLabel;
            Assert.That(helpLabel, Is.Not.Null);
            Assert.That(helpLabel.GetHelpText(), Is.EqualTo(HELP_TEXT));
        }

        [Test]
        public void CreateRichLabelReturnsRichLabel()
        {
            // Arrange
            string color = "red";
            int size = 12;
            string font = "Arial";

            // Act
            var label = _labelFactory.CreateRichLabel(LABEL_TEXT, color, size, font);

            // Assert
            Assert.That(label, Is.InstanceOf<RichLabel>());
            Assert.That(label.GetText(), Contains.Substring(LABEL_TEXT));
            Assert.That(label.GetText(), Contains.Substring(color));
            Assert.That(label.GetText(), Contains.Substring(size.ToString()));
            Assert.That(label.GetText(), Contains.Substring(font));
        }

        [Test]
        public void CreateCustomLabelProxyReturnsCustomLabelProxy()
        {
            // Arrange
            const int TIMEOUT = 1000;

            // Act
            var label = _labelFactory.CreateCustomLabelProxy(TIMEOUT);

            // Assert
            Assert.That(label, Is.InstanceOf<CustomLabelProxy>());
            // Assert.That(label.GetText(), Is.EqualTo(LABEL_TEXT));
        }
    }
}
