using System.Text;

using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.FileSystemProvider;
using DesignPatterns_HW3.Observer;
using DesignPatterns_HW3.Reporter;
using DesignPatterns_HW3.Reporter.Memento;
using DesignPatterns_HW3.Visitor;

using Moq;

namespace DesignPatterns_HW3.Tests.Observer
{
    [TestFixture]
    public class ProgressReporterTests
    {
        private ProgressReporter progressReporter;
        private MemoryStream memoryStream;

        [SetUp]
        public void Setup()
        {
            memoryStream = new MemoryStream();
            progressReporter = new ProgressReporter(memoryStream);
        }

        [TearDown]
        public void TearDown()
        {
            progressReporter.EndTimer();
            memoryStream.Dispose();
        }

        [Test]
        public void StartTimer_ShouldStartTimer()
        {
            // Arrange
            progressReporter.StartTimer(1000);

            // Act
            var snapshot = progressReporter.GetSnapshot();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(snapshot.ExpectedBytesToRead, Is.EqualTo(1000));
                Assert.That(snapshot.ReadBytes, Is.EqualTo(0));
                Assert.That(snapshot.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(0));
                Assert.That(progressReporter.Stopped, Is.False);
                Assert.That(progressReporter.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(0));
            });
        }

        [Test]
        public void Pause_ShouldStopTimer()
        {
            // Arrange
            progressReporter.StartTimer(1000);

            // Act
            progressReporter.Pause();

            // Assert
            Assert.That(progressReporter.Stopped, Is.True);
        }

        [Test]
        public void EndTimer_ShouldStopTimer()
        {
            // Arrange
            progressReporter.StartTimer(1000);

            // Act
            var ms = progressReporter.EndTimer();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(progressReporter.Stopped, Is.True);
                Assert.That(ms, Is.GreaterThanOrEqualTo(0));
            });
        }

        [Test]
        public void GetSnapshot_ShouldReturnCorrectSnapshot()
        {
            // Arrange
            progressReporter.StartTimer(1000);

            // Act
            var snapshot = progressReporter.GetSnapshot();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(snapshot.ExpectedBytesToRead, Is.EqualTo(1000));
                Assert.That(snapshot.ReadBytes, Is.EqualTo(0));
                Assert.That(snapshot.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(0));
            });
        }

        [Test]
        public void Restore_ShouldRestoreFromSnapshot()
        {
            // Arrange
            var snapshot = new ProgressSnapshot(500, 1000, 500);

            // Act
            progressReporter.Restore(snapshot);
            progressReporter.Pause();
            var newSnapshot = progressReporter.GetSnapshot();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(newSnapshot.ExpectedBytesToRead, Is.EqualTo(1000));
                Assert.That(newSnapshot.ReadBytes, Is.EqualTo(500));
                Assert.That(newSnapshot.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(500));
            });
        }

        [Test]
        public void Restore_AfterRestoreShouldUpdateCorrectly()
        {
            // Arrange
            var snapshot = new ProgressSnapshot(500, 1000, 500);
            progressReporter.Restore(snapshot);

            // Act
            // Act
            progressReporter.Update(new Mock<IChecksumCalculator>().Object, new FileMessage("file", 100));

            // Assert
            var newSnapshot = progressReporter.GetSnapshot();
            Assert.That(newSnapshot.ReadBytes, Is.EqualTo(600));
            var output = Encoding.UTF8.GetString(memoryStream.ToArray());
            Assert.That(output, Contains.Substring("\rTotal processed 600b Total processed 60.000000%, remaining time "));
        }

        [Test]
        public void Update_ShouldUpdateFromChecksumCalculatorReadBytes()
        {
            // Arrange
            progressReporter.StartTimer(1000);

            // Act
            progressReporter.Update(new Mock<IChecksumCalculator>().Object, new FileMessage("file", 100));

            // Assert
            var snapshot = progressReporter.GetSnapshot();
            Assert.That(snapshot.ReadBytes, Is.EqualTo(100));
            var output = Encoding.UTF8.GetString(memoryStream.ToArray());
            Assert.That(output, Contains.Substring("\rTotal processed 100b Total processed 10.000000%, remaining time "));
        }

        [Test]
        public void Update_ShouldUpdateFromHashStreamWriterVisitor()
        {
            // Arrange
            progressReporter.StartTimer(1000);

            // Act
            progressReporter.Update(new HashStreamWriterVisitor(memoryStream, It.IsAny<IChecksumCalculator>(), It.IsAny<IFileSystemProvider>()), new FileMessage("file", 100));

            // Assert
            var snapshot = progressReporter.GetSnapshot();
            Assert.That(snapshot.ReadBytes, Is.EqualTo(0));
            var output = Encoding.UTF8.GetString(memoryStream.ToArray());
            Assert.That(output, Contains.Substring("Processing file - with length 100b"));
        }

        [Test]
        public void Update_ShouldUpdateFromHashStreamWriterWithAlreadyProcessedInfo()
        {
            // Arrange
            progressReporter.StartTimer(1000);

            // Act
            progressReporter.Update(new HashStreamWriterVisitor(memoryStream, It.IsAny<IChecksumCalculator>(), It.IsAny<IFileSystemProvider>()), new FileMessage("file", 100, true));

            // Assert
            var snapshot = progressReporter.GetSnapshot();
            Assert.That(snapshot.ReadBytes, Is.EqualTo(100));
            var output = Encoding.UTF8.GetString(memoryStream.ToArray());
            Assert.That(output, Contains.Substring("Processing file - with length 100b"));
            Assert.That(output, Contains.Substring("Total processed 10.000000%, remaining time"));
        }

        [Test]
        public void Update_ShouldThrowExceptionForInvalidSender()
        {
            // Arrange
            progressReporter.StartTimer(1000);

            // Act
            // Assert
            Assert.That(()=> progressReporter.Update(new Mock<IObservable>().Object, new FileMessage("file", 100)), Throws.ArgumentException);
        }

        [Test]
        public void Update_ShouldNotUpdateIfStopped()
        {
            // Arrange
            progressReporter.StartTimer(1000);
            progressReporter.Pause();

            // Act
            progressReporter.Update(new HashStreamWriterVisitor(memoryStream, It.IsAny<IChecksumCalculator>(), It.IsAny<IFileSystemProvider>()), new FileMessage("file", 100));

            // Assert
            var snapshot = progressReporter.GetSnapshot();
            Assert.That(snapshot.ReadBytes, Is.EqualTo(0));
            var output = Encoding.UTF8.GetString(memoryStream.ToArray());
            Assert.That(output, Is.Empty);
        }
    }
}
