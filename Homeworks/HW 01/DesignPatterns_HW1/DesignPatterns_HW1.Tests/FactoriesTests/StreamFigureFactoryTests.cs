using DesignPatterns_HW1.Factories;
using DesignPatterns_HW1.Figures;

namespace DesignPatterns_HW1.Tests.FactoriesTests
{
    [TestFixture]
    public class StreamFigureFactoryTests
    {
        // this is more of an integration test
        [Test]
        public void CreateShouldCreateFromStreamSuccessfully()
        {
            // arrange
            var expectedFigure = new Circle(5.5);
            var expectedString = expectedFigure.ToString();
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, leaveOpen: true);
            writer.Write(expectedString);
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var factory = new StreamFigureFactory(stream);

            // act
            var figure = factory.Create();
            var actualString = figure.ToString();

            // assert
            Assert.That(figure, Is.EqualTo(expectedFigure));
            Assert.That(actualString, Is.EqualTo(expectedString));
        }

        [Test]
        public void DisposeShouldDisposeStreamSuccessfully()
        {
            // arrange
            var stream = new MemoryStream();
            var factory = new StreamFigureFactory(stream);

            // act
            factory.Dispose();
            var canRead = stream.CanRead;

            // assert
            Assert.That(canRead, Is.False);
        }
    }
}
