using System.Text;

using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.Observer;

using Moq;

namespace DesignPatterns_HW3.Tests.ChecksumCalculator
{

    [TestFixture]
    public class BaseChecksumCalculatorTests
    {
        // We will use the MD5ChecksumCalculator as a concrete class to test the BaseChecksumCalculator
        // because the only difference between the concrete classes at the moment is the hash algorithm they use.
        private MD5ChecksumCalculator checksumCalculator;
        

        [SetUp]
        public void SetUp()
        {
            checksumCalculator = new MD5ChecksumCalculator();
        }

        [Test]
        public void Calculate_ShouldReturnCorrectChecksum()
        {
            // Arrange
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("abc"));
            var expectedChecksum = "900150983cd24fb0d6963f7d28e17f72";

            // Act
            var checksum = checksumCalculator.Calculate(stream);

            // Assert
            Assert.That(checksum, Is.EqualTo(expectedChecksum));
        }

        [Test]
        public void Calculate_ShouldBeCalledOnceForFilesSmallerThan4096B()
        {
            // Arrange
            var mockObserver = new Mock<IObserver>();
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("abc"));
            checksumCalculator.Attach(mockObserver.Object);

            // Act
            var checksum = checksumCalculator.Calculate(stream);

            // Assert
            mockObserver.Verify(x => x.Update(It.IsAny<IObservable>(), It.IsAny<FileMessage>()), Times.Exactly(1));
        }


        [Test]
        public void Calculate_ShouldBeCalledManyTimesForFilesBiggerThan4096B()
        {
            // Arrange
            var mockObserver = new Mock<IObserver>();
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(new string('a', 4098)));
            checksumCalculator.Attach(mockObserver.Object);

            // Act
            var checksum = checksumCalculator.Calculate(stream);

            // Assert
            mockObserver.Verify(x => x.Update(It.IsAny<IObservable>(), It.IsAny<FileMessage>()), Times.Exactly(2));
        }
    }
}
