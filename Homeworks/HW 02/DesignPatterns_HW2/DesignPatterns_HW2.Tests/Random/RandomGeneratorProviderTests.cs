using DesignPatterns_HW2.Random;

namespace DesignPatterns_HW2.Tests.Random
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
