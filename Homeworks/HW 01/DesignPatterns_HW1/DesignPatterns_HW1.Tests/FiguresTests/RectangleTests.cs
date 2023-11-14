using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Figures;

namespace DesignPatterns_HW1.Tests.FigureTests
{
    [TestFixture]
    public class RectangleTests
    {
        private const double DELTA = 0.00001;
        private const double A = 5.5;
        private const double B = 6.5;

        [Test]
        public void SidesShouldReturnCorrectValue()
        {
            // arrange
            double expectedA = A;
            double expectedB = B;
            var rectangle = new Rectangle(A, B);

            // act
            var actualA = rectangle.A;
            var actualB = rectangle.B;

            // assert
            Assert.That(actualA, Is.EqualTo(expectedA).Within(DELTA));
            Assert.That(actualB, Is.EqualTo(expectedB).Within(DELTA));
        }

        [Test]
        [TestCase(A, B)]
        [TestCase(B, A)]
        public void PermiterShouldCalculatePerimeterCorrectly(double a, double b)
        {
            // arrange
            double expected = (a + b) * 2;
            var rectangle = new Rectangle(a, b);

            // act
            var actual = rectangle.Perimeter();    

            // assert
            Assert.That(actual, Is.EqualTo(expected).Within(DELTA));
        }

        [Test]
        public void ToStringShouldReturnCorrectString()
        {
            // arrange
            var expected = $"{Rectangle.NAME} {A} {B}";
            var rectangle = new Rectangle(A, B);

            // act
            var actual = rectangle.ToString();

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void EqualShouldReturnFalseIfComparedWithNull()
        {
            // arrange
            var rectangle = new Rectangle(A, B);

            // act
            var result = rectangle.Equals(null);

            // assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void EqualShouldReturnFalseIfComparedWithOtherTypeObject()
        {
            // arrange
            var rectangle = new Rectangle(A, B);

            // act
            var result = rectangle.Equals(new object());

            // assert
            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase(A, B)]
        [TestCase(B, A)]
        public void EqualShouldReturnTrueIfComparedWithIdenticalRectangle(double otherA, double otherB)
        {
            // arrange
            var rectangle = new Rectangle(A, B);

            // act
            var result = rectangle.Equals(new Rectangle(otherA, otherB));

            // assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CloneShouldCreateIdenticalRectangle()
        {
            // arrange
            var rectangle = new Rectangle(A, B);

            // act
            var clonedRectangle = rectangle.Clone() as Rectangle;

            // assert
            Assert.That(rectangle, Is.EqualTo(clonedRectangle));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(-5, 5)]
        [TestCase(5, -5)]
        public void RectangleShouldNotBeInstantiatedWithNotPositiveSides(double a, double b)
        {
            // arrange
            // act
            // assert
            var exception = Assert.Throws<ArgumentException>(() => new Rectangle(a, b));
            Assert.That(exception.Message, Is.EqualTo(ErrorMessages.INVALID_SIDE));
        }
    }
}
