using DesignPatterns_HW2.Factories;
using DesignPatterns_HW2.Labels;
using DesignPatterns_HW2.Providers;

namespace DesignPatterns_HW2.Tests.Labels
{
    [TestFixture]
    public class CustomLabelProxyTests
    {
        private ILabelFactory labelFactory;
        private CustomLabelProxy customLabelProxy;

        [SetUp]
        public void SetUp()
        {
            labelFactory = new LabelFactory();
        }

        private void Initialize(Stream stream, int timeout)
        {
            customLabelProxy = new CustomLabelProxy(labelFactory, stream, timeout);
        }

        [Test]
        public void GetTextShouldReturnCorrectly()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream, leaveOpen: true);
            writer.WriteLine("test");
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            Initialize(stream, 1);

            // Act
            var actualText = customLabelProxy.GetText();

            // Assert
            Assert.That(actualText, Is.EqualTo("test"));
        }

        [Test]
        public void GetTextShouldReturnAskUserToResetAfterTimeoutReached()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream, leaveOpen: true);
            writer.WriteLine("test1");
            writer.WriteLine("True");
            writer.WriteLine("test2");
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            Initialize(stream, 1);

            // Act
            customLabelProxy.GetText();
            customLabelProxy.GetText();
            var actualText = customLabelProxy.GetText();

            // Assert
            Assert.That(actualText, Is.EqualTo("test2"));
        }
    }
}
