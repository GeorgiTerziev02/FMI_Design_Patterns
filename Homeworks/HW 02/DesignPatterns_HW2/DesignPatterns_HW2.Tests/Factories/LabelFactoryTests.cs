using DesignPatterns_HW2.Factories;
using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Tests.Factories
{
    [TestFixture]
    public class LabelFactoryTests
    {
        private const string LABEL_TEXT = "some text";
        private LabelFactory _labelFactory;

        [SetUp]
        public void SetUp()
        {
            _labelFactory = new LabelFactory();
        }

        [Test]
        public void CreateReturnsLabel()
        {
            // Arrange
            // Act
            var label = _labelFactory.Create(LABEL_TEXT);

            // Assert
            Assert.That(label, Is.InstanceOf<Label>());
        }

        [Test]
        public void CreateReturnsNewInstance()
        {
            // Arrange
            // Act
            var first = _labelFactory.Create(LABEL_TEXT);
            var second = _labelFactory.Create(LABEL_TEXT);

            // Assert
            Assert.That(first, Is.Not.SameAs(second));
        }

        [Test]
        public void CreateReturnsLabelWithProvidedText()
        {
            // Arrange
            // Act
            var label = _labelFactory.Create(LABEL_TEXT);

            // Assert
            Assert.That(label.GetText(), Is.EqualTo(LABEL_TEXT));
        }
    }
}
