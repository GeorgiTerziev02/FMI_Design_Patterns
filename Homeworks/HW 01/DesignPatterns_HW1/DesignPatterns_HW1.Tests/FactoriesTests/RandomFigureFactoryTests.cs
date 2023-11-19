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
        public void CreateShouldCreateTriangleSuccessfullyEvenWithRandomReturnsNegatives()
        {
            // arrange
            var index = 0;
            var negativeSides = new double[] { -SIDES[0], -SIDES[1], -SIDES[2] };
            var expectedFigure = new Triangle(SIDES[0] * 100, SIDES[1] * 100, SIDES[2] * 100);
            var randomGeneratorMock = new Mock<IRandomGenerator>();
            randomGeneratorMock.Setup(x => x.NextDouble()).Returns(() => negativeSides[index++]);
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

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(2, 2, 10)]
        [TestCase(2, 10, 2)]
        [TestCase(10, 2, 2)]
        public void CreateTriangleShouldTryAgainIfTheGeneratedTriangleStringIsInvalid(double invalidA, double invalidB, double invalidC)
        {
            // arrange
            var index = 0;
            var invalidAndValidSides = new double[] { invalidA, invalidB, invalidC, SIDES[0], SIDES[1], SIDES[2] };
            var expectedFigure = new Triangle(SIDES[0] * 100, SIDES[1] * 100, SIDES[2] * 100);
            var randomGeneratorMock = new Mock<IRandomGenerator>();
            randomGeneratorMock.Setup(x => x.NextDouble()).Returns(() => invalidAndValidSides[index++]);
            randomGeneratorMock.Setup(x => x.Next(0, 3)).Returns(0);

            var factory = new RandomFigureFactory(randomGeneratorMock.Object);

            // act
            var figure = factory.Create();

            // assert
            Assert.That(figure, Is.EqualTo(expectedFigure));
        }

        [Test]
        public void DisposeShouldNotThrow()
        {
            // arrange
            var randomGeneratorMock = new Mock<IRandomGenerator>();
            var factory = new RandomFigureFactory(randomGeneratorMock.Object);

            // act
            // assert
            Assert.DoesNotThrow(() => factory.Dispose());
        }
    }
}
