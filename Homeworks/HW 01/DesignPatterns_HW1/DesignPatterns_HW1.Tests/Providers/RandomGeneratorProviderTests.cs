using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Providers;

namespace DesignPatterns_HW1.Tests.Providers
{
    [TestFixture]
    public class RandomGeneratorProviderTests
    {
        [Test]
        public void GetRandomGeneratorShouldReturnCorrectly()
        {
            // arrange
            var randomGeneratorProvider = new RandomGeneratorProvider();

            // act
            var randomGenerator = randomGeneratorProvider.GetRandomGenerator();

            // assert
            Assert.That(randomGenerator, Is.InstanceOf<RandomGenerator>());
        }
    }
}
