using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Creators;
using DesignPatterns_HW1.Figures;

namespace DesignPatterns_HW1.Tests.CreatorsTests
{
    [TestFixture]
    public class FigureCreatorTests
    {
        private const double DELTA = 0.00001;
        private const double A = 5.5;
        private const double B = 6.5;
        private const double C = 7.5;

        [Test]
        public void CreateShouldCreateCircleSuccessfully()
        {
            // arrange
            var expectedFigure = new Circle(A);
            var expectedString = expectedFigure.ToString();

            // act
            var figure = FigureCreator.CreateFigure(expectedString);
            var actualString = figure.ToString();

            // assert
            Assert.That(figure, Is.EqualTo(expectedFigure));
            Assert.That(actualString, Is.EqualTo(expectedString));
        }

        [Test]
        public void CreateShouldCreateRectangleSuccessfully()
        {
            // arrange
            var expectedFigure = new Rectangle(A, B);
            var expectedString = expectedFigure.ToString();

            // act
            var figure = FigureCreator.CreateFigure(expectedString);
            var actualString = figure.ToString();

            // assert
            Assert.That(figure, Is.EqualTo(expectedFigure));
            Assert.That(actualString, Is.EqualTo(expectedString));
        }

        [Test]
        public void CreateShouldCreateTriangleSuccessfully()
        {
            // arrange
            var expectedFigure = new Triangle(A, B, C);
            var expectedString = expectedFigure.ToString();

            // act
            var figure = FigureCreator.CreateFigure(expectedString);
            var actualString = figure.ToString();

            // assert
            Assert.That(figure, Is.EqualTo(expectedFigure));
            Assert.That(actualString, Is.EqualTo(expectedString));
        }

        [Test]
        [TestCase("aaa")]
        [TestCase(Circle.NAME)]
        [TestCase($"{Circle.NAME} a a")]
        [TestCase(Rectangle.NAME)]
        [TestCase($"{Rectangle.NAME} a")]
        [TestCase($"{Rectangle.NAME} a a a")]
        [TestCase($"{Rectangle.NAME} a a")]
        [TestCase(Triangle.NAME)]
        [TestCase($"{Triangle.NAME} a a")]
        [TestCase($"{Triangle.NAME} a a a a")]
        [TestCase($"{Triangle.NAME} a a a")]
        public void CreateShouldThrowsIfInvalidInput(string input)
        {
            // arrange
            // act
            // assert
            var exception = Assert.Throws<ArgumentException>(() => FigureCreator.CreateFigure(input));
            Assert.That(exception.Message, Is.EqualTo(ErrorMessages.INVALID_INPUT));
        }

        [Test]
        [TestCase("aa a")]
        [TestCase("aa a a")]
        [TestCase("aa a a a")]
        public void CreateShouldThrowsIfFigureTypeInvalid(string input)
        {
            // arrange
            // act
            // assert
            var exception = Assert.Throws<ArgumentException>(() => FigureCreator.CreateFigure(input));
            Assert.That(exception.Message, Is.EqualTo(ErrorMessages.INVALID_FIGURE_TYPE));
        }
    }
}
