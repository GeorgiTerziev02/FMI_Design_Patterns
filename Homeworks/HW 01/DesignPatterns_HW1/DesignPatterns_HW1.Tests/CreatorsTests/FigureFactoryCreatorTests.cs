using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Creators;
using DesignPatterns_HW1.Factories;
using System.ComponentModel;

namespace DesignPatterns_HW1.Tests.CreatorsTests
{
    [TestFixture]
    public class FigureFactoryCreatorTests
    {
        private const string FILENAME = "test.txt";

        [Test]
        [TestCase("1")]
        [TestCase("Random")]
        public void CreateShouldCreateRandomFigureFactorySuccessfully(string input)
        {
            // arrange
            // act
            var factory = FigureFactoryCreator.CreateFactory(input);

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
            var factory = FigureFactoryCreator.CreateFactory(input);

            // assert
            Assert.That(factory, Is.InstanceOf<StreamFigureFactory>());
        }

        // TODO: more interfaces?
        //[Test]
        //[TestCase($"3 {FILENAME}")]
        //[TestCase($"File {FILENAME}")]
        //public void CreateShouldCreateStreamFigureFactoryWithFileSourceSuccessfully(string input)
        //{
        //    // arrange
        //    var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        //    var filePath = tokens[1];
        //    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None)) { }

        //    // act
        //    var factory = FigureFactoryCreator.CreateFactory(input);

        //    // assert
        //    Assert.That(factory, Is.InstanceOf<StreamFigureFactory>());

        //    File.Delete(filePath);
        //}

        [Test]
        [TestCase("a")]
        [TestCase("4")]
        [TestCase("a a")]
        public void CreateShouldThrowIfInvalidInputFigure(string input)
        {
            // arrange
            // act
            // assert
            var exception = Assert.Throws<InvalidEnumArgumentException>(() => FigureFactoryCreator.CreateFactory(input));
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
            var exception = Assert.Throws<ArgumentException>(() => FigureFactoryCreator.CreateFactory(input));
            Assert.That(exception.Message, Is.EqualTo(ErrorMessages.INVALID_INPUT));
        }
    }
}
