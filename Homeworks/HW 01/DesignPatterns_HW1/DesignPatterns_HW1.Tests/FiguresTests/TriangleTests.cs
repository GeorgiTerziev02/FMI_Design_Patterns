using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Figures;

namespace DesignPatterns_HW1.Tests.FigureTests
{
    [TestFixture]
    public class TriangleTests
    {
        private const double DELTA = 0.00001;
        private const double A = 5.5;
        private const double B = 6.5;
        private const double C = 7.5;

        [Test]
        public void SidesShouldReturnCorrectValue()
        {
            // arrange
            double expectedA = A;
            double expectedB = B;
            double expectedC = C;
            var triangle = new Triangle(A, B, C);

            // act
            var actualA = triangle.A;
            var actualB = triangle.B;
            var actualC = triangle.C;

            // assert
            Assert.That(actualA, Is.EqualTo(expectedA).Within(DELTA));
            Assert.That(actualB, Is.EqualTo(expectedB).Within(DELTA));
            Assert.That(actualC, Is.EqualTo(expectedC).Within(DELTA));
        }

        [Test]
        [TestCase(A, B, C)]
        [TestCase(A, C, B)]
        [TestCase(B, C, A)]
        [TestCase(B, A, C)]
        [TestCase(C, A, B)]
        [TestCase(C, B, A)]
        public void PerimeterShouldCalculatePerimeterCorrectly(double a, double b, double c)
        {
            // arrange
            double expected = a + b + c;
            var triangle = new Triangle(a, b, c);

            // act
            var actual = triangle.Perimeter();

            // assert
            Assert.That(actual, Is.EqualTo(expected).Within(DELTA));
        }

        [Test]
        public void ToStringShouldReturnCorrectString()
        {
            // arrange
            var expected = $"{Triangle.NAME} {A} {B} {C}";
            var triangle = new Triangle(A, B, C);

            // act
            var actual = triangle.ToString();

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void EqualShouldReturnFalseIfComparedWithNull()
        {
            // arrange
            var triangle = new Triangle(A, B, C);

            // act
            var result = triangle.Equals(null);

            // assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void EqualShouldReturnFalseIfComparedWithOtherTypeObject()
        {
            // arrange
            var triangle = new Triangle(A, B, C);

            // act
            var result = triangle.Equals(new object());

            // assert
            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase(A, B, C)]
        [TestCase(A, C, B)]
        [TestCase(B, A, C)]
        [TestCase(B, C, A)]
        [TestCase(C, A, B)]
        [TestCase(C, B, A)]
        public void EqualShouldReturnTrueIfComparedWithIdenticaltriangle(double otherA, double otherB, double otherC)
        {
            // arrange
            var triangle = new Triangle(A, B, C);

            // act
            var result = triangle.Equals(new Triangle(otherA, otherB, otherC));

            // assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CloneShouldCreateIdenticaltriangle()
        {
            // arrange
            var triangle = new Triangle(A, B, C);

            // act
            var clonedtriangle = triangle.Clone() as Triangle;

            // assert
            Assert.That(triangle, Is.EqualTo(clonedtriangle));
        }

        [Test]
        [TestCase(-5.5, 6.5, 7.5)]
        [TestCase(5.5, -6.5, 7.5)]
        [TestCase(5.5, 6.5, -7.5)]
        [TestCase(0, 0, 0)]
        public void TriangleShouldNotBeInstantiatedWithNotPositiveSides(double a, double b, double c)
        {
            // arrange
            // act
            // assert
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
            Assert.That(exception.Message, Is.EqualTo(ErrorMessages.INVALID_SIDE));
        }

        [Test]
        [TestCase(1.5, 2.5, 5)]
        [TestCase(1.5, 5, 2.5)]
        [TestCase(5, 1.5, 2.5)]
        public void TriangleShouldNotBeInstantiatedWithoutFulfilledTriangleInequality(double a, double b, double c)
        {
            // arrange
            // act
            // assert
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
            Assert.That(exception.Message, Is.EqualTo(ErrorMessages.INVALID_TRIANGLE));
        }
    }
}
