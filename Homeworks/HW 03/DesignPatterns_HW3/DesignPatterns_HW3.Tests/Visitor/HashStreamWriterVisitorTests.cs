﻿using System.Text;

using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.Observer;
using DesignPatterns_HW3.Visitor;
using DesignPatterns_HW3.Visitor.Memento;

using Moq;

namespace DesignPatterns_HW3.Tests.Visitor
{
    [TestFixture]
    public class HashStreamWriterVisitorTests
    {
        private const string TEST_DIRECTORY_PATH = "..\\..\\..\\Resources\\Files\\HashStreamWriterVisitor\\";
        private const string MOCK_CHECKSUM = "Checksum";

        private MemoryStream memoryStream;
        private HashStreamWriterVisitor hashStreamWriterVisitor;
        private Mock<IChecksumCalculator> checksumCalculatorMock;

        [SetUp]
        public void Setup()
        {
            memoryStream = new MemoryStream();
            checksumCalculatorMock = new Mock<IChecksumCalculator>();
            checksumCalculatorMock.Setup(x => x.Calculate(It.IsAny<Stream>())).Returns(MOCK_CHECKSUM);

            // This is actually not a unit test, but an integration test :(
            // Using real fileSystemProvider because it is easier to test, the folder has already been set up with the mock files
            var fileSystemProvider = new DesignPatterns_HW3.FileSystemProvider.FileSystemProvider();
            hashStreamWriterVisitor = new HashStreamWriterVisitor(memoryStream, checksumCalculatorMock.Object, fileSystemProvider);
        }

        [TearDown]
        public void TearDown()
        {
            memoryStream.Dispose();
            hashStreamWriterVisitor.Dispose();
        }

        [Test]
        public void Attach_ShouldAttachObserverToChecksumCalculator()
        {
            // Arrange
            var mockObserver = new Mock<IObserver>();

            // Act
            hashStreamWriterVisitor.Attach(mockObserver.Object);

            // Assert
            checksumCalculatorMock.Verify(x => x.Attach(mockObserver.Object), Times.Once);
        }

        [Test]
        public void VisitFile_ShouldVisitFileAndPrintChecksum()
        {
            // Arrange
            var file = new File(TEST_DIRECTORY_PATH + "file.txt", 3);

            // Act
            hashStreamWriterVisitor.Visit(file);

            // Assert
            var output = Encoding.UTF8.GetString(memoryStream.ToArray());
            Assert.That(output, Contains.Substring($"Checksum - {MOCK_CHECKSUM}"));
        }

        [Test]
        public void VisitFile_ShouldNotVisitWithInvalidFilePath()
        {
            // Arrange
            var file = new File(TEST_DIRECTORY_PATH + "invalid.txt", 3);

            // Act
            hashStreamWriterVisitor.Visit(file);

            // Assert
            var output = Encoding.UTF8.GetString(memoryStream.ToArray());
            Assert.That(output, Contains.Substring($"Error accessing file"));
        }

        [Test]
        public void VisitFile_ShouldVisitFileOnce()
        {
            // Arrange
            var file = new File(TEST_DIRECTORY_PATH + "file.txt", 3);
            var mockObserver = new Mock<IObserver>();
            hashStreamWriterVisitor.Attach(mockObserver.Object);

            // Act
            hashStreamWriterVisitor.Visit(file);
            hashStreamWriterVisitor.Visit(file);

            // Assert
            mockObserver.Verify(x => x.Update(It.IsAny<IObservable>(), It.IsAny<FileMessage>()), Times.Exactly(2));

            var output = Encoding.UTF8.GetString(memoryStream.ToArray());
            var expectedSubstring = $"\r\nChecksum - {MOCK_CHECKSUM}\r\n";
            Assert.That(output, Is.EqualTo(expectedSubstring));
            Assert.That(output, Has.Length.EqualTo(expectedSubstring.Length));
        }

        [Test]
        public void VisitDirectory_ShouldVisitAllChildren()
        {
            // Arrange
            var file1 = new File(TEST_DIRECTORY_PATH + "Directory\\f1.txt", 3);
            var file2 = new File(TEST_DIRECTORY_PATH + "Directory\\f2.txt", 3);
            var dir = new Directory(TEST_DIRECTORY_PATH + "Directory", 6, new[] { file1, file2 });

            // Act
            hashStreamWriterVisitor.Visit(dir);

            // Assert
            var output = Encoding.UTF8.GetString(memoryStream.ToArray());
            var snapshot = hashStreamWriterVisitor.GetSnapshot();
            Assert.Multiple(() =>
            {
                Assert.That(output, Is.EqualTo($"\r\nChecksum - {MOCK_CHECKSUM}\r\n\r\nChecksum - {MOCK_CHECKSUM}\r\n"));
                Assert.That(snapshot.Root, Is.EqualTo(dir));
                Assert.That(snapshot.Visited, Has.Count.EqualTo(3));
                Assert.That(hashStreamWriterVisitor.Stopped, Is.True);
            });
        }

        [Test]
        public void Pause_ShouldStopTheVisitor()
        {
            // Arrange
            var dir = new Directory(TEST_DIRECTORY_PATH + "dir", 3, []);

            // Act  
            hashStreamWriterVisitor.Pause();
            hashStreamWriterVisitor.Visit(dir);

            // Assert
            Assert.Multiple(() =>
            {
                var output = Encoding.UTF8.GetString(memoryStream.ToArray());
                Assert.That(output, Is.Empty);
                Assert.That(hashStreamWriterVisitor.Stopped, Is.True);
            });
        }

        [Test]
        public void Reset_ShouldResetVisited()
        {
            // Arrange
            var file = new File(TEST_DIRECTORY_PATH + "file.txt", 3);
            var mockObserver = new Mock<IObserver>();
            hashStreamWriterVisitor.Attach(mockObserver.Object);

            // Act
            hashStreamWriterVisitor.Visit(file);
            hashStreamWriterVisitor.Reset();
            hashStreamWriterVisitor.Visit(file);

            // Assert
            mockObserver.Verify(x => x.Update(It.IsAny<IObservable>(), It.IsAny<FileMessage>()), Times.Exactly(2));

            var output = Encoding.UTF8.GetString(memoryStream.ToArray());
            var expectedSubstring = $"\r\nChecksum - {MOCK_CHECKSUM}\r\n\r\nChecksum - {MOCK_CHECKSUM}\r\n";
            Assert.That(output, Is.EqualTo(expectedSubstring));
            Assert.That(output, Has.Length.EqualTo(expectedSubstring.Length));
        }

        [Test]
        public void GetSnapshot_ShouldReturnCorrectSnapshotForFile()
        {
            // Arrange
            var file = new File(TEST_DIRECTORY_PATH + "file.txt", 3);

            // Act
            hashStreamWriterVisitor.Visit(file);

            // Assert
            var snapshot = hashStreamWriterVisitor.GetSnapshot();
            Assert.Multiple(() =>
            {
                Assert.That(snapshot.Root, Is.Null);
                Assert.That(snapshot.Visited, Has.Count.EqualTo(1));
                Assert.That(snapshot.Visited, Contains.Item(file.RelativePath));
            });
        }

        [Test]
        public void GetSnapshot_ShouldReturnCorrectShanpshotForDirectory()
        {
            // Arrange
            var file1 = new File(TEST_DIRECTORY_PATH + "Directory\\f1.txt", 3);
            var file2 = new File(TEST_DIRECTORY_PATH + "Directory\\f2.txt", 3);
            var dir = new Directory(TEST_DIRECTORY_PATH + "Directory", 6, new [] { file1, file2 });

            // Act
            hashStreamWriterVisitor.Visit(dir);

            // Assert
            var snapshot = hashStreamWriterVisitor.GetSnapshot();
            Assert.Multiple(() =>
            {
                Assert.That(snapshot.Root, Is.EqualTo(dir));
                Assert.That(snapshot.Visited, Has.Count.EqualTo(3));
                Assert.That(snapshot.Visited, Contains.Item(dir.RelativePath));
                Assert.That(snapshot.Visited, Contains.Item(file1.RelativePath));
                Assert.That(snapshot.Visited, Contains.Item(file2.RelativePath));
            });
        }

        [Test]
        public void Restore_ShouldRestoreVisitorState()
        {
            // Arrange
            var file1 = new File(TEST_DIRECTORY_PATH + "Directory\\f1.txt", 3);
            var file2 = new File(TEST_DIRECTORY_PATH + "Directory\\f2.txt", 3);
            var dir = new Directory(TEST_DIRECTORY_PATH + "Directory", 6, new[] { file1, file2 });
            var mockSnapshot = new ProcessedFilesSnapshot(new [] { dir.RelativePath, file1.RelativePath, file2.RelativePath }, dir);

            // Act
            hashStreamWriterVisitor.Restore(mockSnapshot);

            // Assert
            var newSnapshot = hashStreamWriterVisitor.GetSnapshot();
            Assert.Multiple(() =>
            {
                Assert.That(newSnapshot.Root, Is.EqualTo(mockSnapshot.Root));
                Assert.That(newSnapshot.Visited, Has.Count.EqualTo(mockSnapshot.Visited.Count));
                Assert.That(newSnapshot.Visited, Is.EquivalentTo(mockSnapshot.Visited));
                var output = Encoding.UTF8.GetString(memoryStream.ToArray());
                Assert.That(output, Is.Empty);
            });
        }
    }
}
