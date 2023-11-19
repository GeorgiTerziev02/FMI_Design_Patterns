using DesignPatterns_HW1.Common;

namespace DesignPatterns_HW1.Tests.CommonTests
{
    [TestFixture]
    public class HelperTests
    {
        [Test]
        public void DoubleParseTokensShouldParseWhenValidInputAndSkipFirstValue()
        {
            // arrange
            var tokens = new string[] { "4.55", "1.1", "2", "3" };
            var expected = new double[] { 1.1, 2, 3 };
            var expectedLength = 4;
            double[] result;
            // act
            Helper.DoubleParseTokens(tokens, expectedLength, out result);
            // assert
            Assert.That(expected.SequenceEqual(result), Is.True);
        }

        [Test]
        public void DoubleParseTokensShouldThrowWhenInvalidExpectedLength()
        {
            // arrange
            var tokens = new string[] { "4.55", "1.1", "2", "3" };
            var expectedLength = 5;
            double[] result;
            // act
            // assert
            var ex = Assert.Throws<ArgumentException>(() => Helper.DoubleParseTokens(tokens, expectedLength, out result));
            Assert.That(ex.Message, Is.EqualTo(ErrorMessages.INVALID_INPUT));
        }

        [Test]
        public void DoubleParseTokensShouldThrowWhenInvalidDoubleArgument()
        {
            // arrange
            var tokens = new string[] { "4.55", "1.1", "2", "3a" };
            var expectedLength = 4;
            double[] result;
            // act
            // assert
            var ex = Assert.Throws<ArgumentException>(() => Helper.DoubleParseTokens(tokens, expectedLength, out result));
            Assert.That(ex.Message, Is.EqualTo(ErrorMessages.INVALID_INPUT));
        }

        [Test]
        public void AssertTokensLengthShouldNotThrowLengthEqualsExpected()
        {
            // arrange
            var expected = 3;
            var arr = new string[3];
            // act
            // assert
            Assert.DoesNotThrow(() => Helper.AssertTokensLength(arr, expected));
        }

        [Test]
        public void AssertTokensLengthShouldThrowLengthDoesNotEqualsExpected()
        {
            // arrange
            var expected = 4;
            var arr = new string[3];
            // act
            // assert
            var ex = Assert.Throws<ArgumentException>(() => Helper.AssertTokensLength(arr, expected));
            Assert.That(ex.Message, Is.EqualTo(ErrorMessages.INVALID_INPUT));
        }

        [Test]
        [TestCase(3, 4, 5)]
        [TestCase(5, 3, 4)]
        [TestCase(4, 5, 3)]
        public void IsValidTriangleShouldReturnTrueWhenValidTriangle(double a, double b, double c)
        {
            // arrange
            // act
            var result = Helper.IsValidTriangle(a, b, c);

            // assert
            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(3, 3, 7)]
        [TestCase(3, 7, 3)]
        [TestCase(7, 3, 3)]
        public void IsValidTriangleShouldReturnTrueWhenInvalidTriangle(double a, double b, double c)
        {
            // arrange
            // act
            var result = Helper.IsValidTriangle(a, b, c);

            // assert
            Assert.That(result, Is.False);
        }
    }
}
