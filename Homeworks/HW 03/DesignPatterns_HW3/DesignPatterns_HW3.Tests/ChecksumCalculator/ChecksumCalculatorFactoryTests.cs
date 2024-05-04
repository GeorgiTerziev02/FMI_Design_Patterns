using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.ChecksumCalculator;

namespace DesignPatterns_HW3.Tests.ChecksumCalculator
{
    [TestFixture]
    public class ChecksumCalculatorFactoryTests
    {
        private ChecksumCalculatorFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new ChecksumCalculatorFactory();
        }

        [Test]
        public void Create_ShouldCreateMd5ChecksumCalculator()
        {
            // Arrange
            // Act
            var result = factory.Create("md5");

            // Assert
            Assert.That(result, Is.InstanceOf<MD5ChecksumCalculator>());
        }

        [Test]
        public void Create_ShouldCreateSha256ChecksumCalculator()
        {
            // Arrange
            // Act
            var result = factory.Create("sha256");

            // Assert
            Assert.That(result, Is.InstanceOf<SHA256ChecksumCalculator>());
        }

        [Test]
        public void Create_ShouldCreateNoMatterTheCasing()
        {
            var result1 = factory.Create("Md5");
            var result2 = factory.Create("ShA256");

            Assert.That(result1, Is.InstanceOf<MD5ChecksumCalculator>());
            Assert.That(result2, Is.InstanceOf<SHA256ChecksumCalculator>());
        }

        [Test]
        public void Create_WhenCalledWithUnknownAlgorithmShouldThrowException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => factory.Create("unknown"));
        }
    }
}
