using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Figures;

namespace DesignPatterns_HW1.Tests.FigureTests
{
    [TestFixture]
    public class CircleTests
    {
        private const double DELTA = 0.00001;
        private const double RADIUS = 5.55;

        [Test]
        public void RadiusShouldReturnCorrectValue()
        {
            // arrange
            double expected = RADIUS;
            var circle = new Circle(RADIUS);

            // act
            var actual = circle.Radius;

            // assert
            Assert.IsTrue(actual.Equals(expected));
            Assert.That(expected, Is.EqualTo(actual).Within(DELTA));
        }

        [Test]
        public void PermiterShouldCalculatePerimeterCorrectly()
        {
            // arrange
            double expected = 2 * RADIUS * Math.PI;
            var circle = new Circle(RADIUS);

            // act
            var actual = circle.Perimeter();

            // assert
            Assert.That(actual, Is.EqualTo(expected).Within(DELTA));
        }

        [Test]
        public void ToStringShouldReturnCorrectString()
        {
            // arrange
            var expected = $"{Circle.NAME} {RADIUS}";
            var circle = new Circle(RADIUS);

            // act
            var actual = circle.ToString();

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void EqualShouldReturnFalseIfComparedWithNull()
        {
            // arrange
            var circle = new Circle(RADIUS);

            // act
            var result = circle.Equals(null);

            // assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void EqualShouldReturnFalseIfComparedWithOtherTypeObject()
        {
            // arrange
            var circle = new Circle(RADIUS);

            // act
            var result = circle.Equals(new object());

            // assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void CloneShouldCreateIdenticalCircle()
        {
            // arrange
            var circle = new Circle(RADIUS);

            // act
            var clonedCircle = circle.Clone() as Circle;

            // assert
            Assert.That(circle, Is.EqualTo(clonedCircle));
        }

        [Test]
        [TestCase(-5.5)]
        [TestCase(0)]
        public void CircleShouldNotBeInstantiatedWithNotPositiveRadius(double radius)
        {
            // arrange
            // act
            // assert
            var ex = Assert.Throws<ArgumentException>(() => new Circle(radius));
            Assert.That(ex.Message, Is.EqualTo(ErrorMessages.INVALID_RADIUS));
        }
    }
}
