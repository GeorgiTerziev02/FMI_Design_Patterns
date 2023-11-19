using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Creators;
using DesignPatterns_HW1.Factories;
using DesignPatterns_HW1.Figures;
using DesignPatterns_HW1.Providers;
using Moq;
using System.ComponentModel;

namespace DesignPatterns_HW1.Tests.CreatorsTests
{
    [TestFixture]
    public class FigureFactoryCreatorTests
    {
        private const string FILENAME = "test.txt";
        private Mock<IRandomGeneratorProvider> randomGeneratorProviderMock;
        private Mock<IStreamProvider> streamProvidersMock;
        private IFigureFactoryCreator figureFactoryCreator;
        private IFigure figure;
        private MemoryStream memoryStream;

        [SetUp]
        public void Setup()
        {
            randomGeneratorProviderMock = new Mock<IRandomGeneratorProvider>();
            randomGeneratorProviderMock.Setup(x => x.GetRandomGenerator()).Returns(new RandomGenerator());
            streamProvidersMock = new Mock<IStreamProvider>();
            InitMemoryStream();
            streamProvidersMock.Setup(x => x.OpenFileForRead(FILENAME)).Returns(memoryStream);
            streamProvidersMock.Setup(x => x.GetStdIn()).Returns(memoryStream);
            figureFactoryCreator = new FigureFactoryCreator(randomGeneratorProviderMock.Object, streamProvidersMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            memoryStream?.Dispose();
        }

        [Test]
        [TestCase("1")]
        [TestCase("Random")]
        public void CreateShouldCreateRandomFigureFactorySuccessfully(string input)
        {
            // arrange
            // act
            var factory = figureFactoryCreator.CreateFactory(input);

            // assert
            Assert.That(factory, Is.InstanceOf<RandomFigureFactory>());
        }

        [Test]
        [TestCase("2")]
        [TestCase("Console")]
        public void CreateShouldCreateStreamFigureFactoryWithConsoleSourceSuccessfully(string input)
        {
            // arrange
            // act
            var factory = figureFactoryCreator.CreateFactory(input);

            // assert
            Assert.That(factory, Is.InstanceOf<StreamFigureFactory>());
        }

        [Test]
        [TestCase($"3 {FILENAME}")]
        [TestCase($"File {FILENAME}")]
        public void CreateShouldCreateStreamFigureFactoryWithFileSourceSuccessfully(string input)
        {
            // arrange
            // act
            var factory = figureFactoryCreator.CreateFactory(input);

            // assert
            Assert.That(factory, Is.InstanceOf<StreamFigureFactory>());
        }


        [Test]
        [TestCase("2")]
        [TestCase("Console")]
        [TestCase($"3 {FILENAME}")]
        [TestCase($"File {FILENAME}")]
        public void CreateShouldCreateStreamFigureFactoryThatCanReadSuccessfully(string input)
        {
            // arrange
            // act
            var factory = figureFactoryCreator.CreateFactory(input);
            var figure = factory.Create();

            // assert
            Assert.That(figure, Is.EqualTo(this.figure));
        }

        [Test]
        [TestCase("a")]
        [TestCase("4")]
        [TestCase("a a")]
        public void CreateShouldThrowIfInvalidInputFigure(string input)
        {
            // arrange
            // act
            // assert
            var exception = Assert.Throws<InvalidEnumArgumentException>(() => figureFactoryCreator.CreateFactory(input));
            Assert.That(exception.Message, Is.EqualTo(ErrorMessages.INVALID_FACTORY_TYPE));
        }

        [Test]
        [TestCase("File")]
        [TestCase("3")]
        [TestCase("3 a a")]
        public void CreateShouldThrowIfInvalidInput(string input)
        {
            // arrange
            // act
            // assert
            var exception = Assert.Throws<ArgumentException>(() => figureFactoryCreator.CreateFactory(input));
            Assert.That(exception.Message, Is.EqualTo(ErrorMessages.INVALID_INPUT));
        }


        private void InitMemoryStream()
        {
            memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream, leaveOpen: true);
            figure = new Circle(5.5);
            var str = figure.ToString();
            writer.Write(str);
            writer.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);
            writer.Dispose();
        }
    }
}
