using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Factories;
using DesignPatterns_HW1.Figures;
using Moq;

namespace DesignPatterns_HW1.Tests.FactoriesTests
{
    [TestFixture]
    public class RandomFigureFactoryTests
    {
        private readonly static double[] SIDES = new double[] { 0.55, 0.65, 0.75 };

        [Test]
        public void CreateShouldCreateRandomFigureSuccessfully()
        {
            // arrange
            var factory = new RandomFigureFactory(new RandomGenerator());

            // act
            var figure = factory.Create();

            // assert
            Assert.That(figure, Is.Not.Null);
        }

        [Test]
        public void CreateShouldCreateCircleSuccessfully()
        {
            // arrange
            var expectedFigure = new Circle(SIDES[0] * 100);
            var randomGeneratorMock = new Mock<IRandomGenerator>();
            randomGeneratorMock.Setup(x => x.NextDouble()).Returns(() => SIDES[0]);
            randomGeneratorMock.Setup(x => x.Next(0, 3)).Returns(2);

            var factory = new RandomFigureFactory(randomGeneratorMock.Object);

            // act
            var figure = factory.Create();

            // assert
            Assert.That(figure, Is.EqualTo(expectedFigure));
        }

        [Test]
        public void CreateShouldCreateRectangleSuccessfully()
        {
            // arrange
            var index = 0;
            var expectedFigure = new Rectangle(SIDES[0] * 100, SIDES[1] * 100);
            var randomGeneratorMock = new Mock<IRandomGenerator>();
            randomGeneratorMock.Setup(x => x.NextDouble()).Returns(() => SIDES[index++]);
            randomGeneratorMock.Setup(x => x.Next(0, 3)).Returns(1);

            var factory = new RandomFigureFactory(randomGeneratorMock.Object);

            // act
            var figure = factory.Create();

            // assert
            Assert.That(figure, Is.EqualTo(expectedFigure));
        }

        [Test]
        public void CreateShouldCreateTriangleSuccessfully()
        {
            // arrange
            var index = 0;
            var expectedFigure = new Triangle(SIDES[0] * 100, SIDES[1] * 100, SIDES[2] * 100);
            var randomGeneratorMock = new Mock<IRandomGenerator>();
            randomGeneratorMock.Setup(x => x.NextDouble()).Returns(() => SIDES[index++]);
            randomGeneratorMock.Setup(x => x.Next(0, 3)).Returns(0);

            var factory = new RandomFigureFactory(randomGeneratorMock.Object);

            // act
            var figure = factory.Create();

            // assert
            Assert.That(figure, Is.EqualTo(expectedFigure));
        }

        [Test]
        public void CreateShouldThrowIfGeneratorReturnsInvalid()
        {
            // arrange
            var randomGeneratorMock = new Mock<IRandomGenerator>();
            randomGeneratorMock.Setup(x => x.NextDouble()).Returns(5);
            randomGeneratorMock.Setup(x => x.Next(0, 3)).Returns(3);

            var factory = new RandomFigureFactory(randomGeneratorMock.Object);

            // act
            // assert
            Assert.That(() => factory.Create(), Throws.Exception);
        }
    }
}
