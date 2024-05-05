using System.Text;

using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3.Tests.Visitor
{
    [TestFixture]
    public class ReportWriterVisitorTests
    {
        private ReportWriterVisitor visitor;
        private MemoryStream outputStream;

        [SetUp]
        public void SetUp()
        {
            outputStream = new MemoryStream();
            visitor = new ReportWriterVisitor(outputStream);
        }

        [TearDown]
        public void TearDown()
        {
            outputStream.Dispose();
        }

        [Test]
        public void VisitFile_ShouldVisitFile()
        {
            // Arrange
            var file = new File("test.txt", 3);

            // Act
            visitor.Visit(file);

            // Assert
            var output = Encoding.UTF8.GetString(outputStream.ToArray());
            Assert.That(output, Contains.Substring("We will file visit: test.txt - 3b"));
        }

        [Test]
        public void VisitFile_ShouldNotVisitFileTwice()
        {
            // Arrange
            var file = new File("test.txt", 3);

            // Act
            visitor.Visit(file);
            visitor.Visit(file);

            // Assert
            var output = Encoding.UTF8.GetString(outputStream.ToArray());
            Assert.That(output, Is.EqualTo("We will file visit: test.txt - 3b\r\n"));
        }

        [Test]
        public void VisitDirectory_ShouldVisitAllChildren()
        {
            // Arrange
            var directory = new Directory("test", 0, []);
            var file1 = new File("test1.txt", 1);
            var file2 = new File("test2.txt", 2);
            directory.AddChild(file1);
            directory.AddChild(file2);

            // Act
            visitor.Visit(directory);

            // Assert
            var output = Encoding.UTF8.GetString(outputStream.ToArray());
            Assert.That(output, Contains.Substring("We will file visit: test - 3b"));
            Assert.That(output, Contains.Substring("We will file visit: test1.txt - 1b"));
            Assert.That(output, Contains.Substring("We will file visit: test2.txt - 2b"));
        }

        [Test]
        public void VisitDirectory_ShouldNotVisitDirectoryTwice()
        {
            // Arrange
            var directory = new Directory("test", 0, []);
            var file1 = new File("test1.txt", 1);
            var file2 = new File("test2.txt", 2);
            directory.AddChild(file1);
            directory.AddChild(file2);

            // Act
            visitor.Visit(directory);
            visitor.Visit(directory);

            // Assert
            var output = Encoding.UTF8.GetString(outputStream.ToArray());
            Assert.That(output, Is.EqualTo("We will file visit: test - 3b\r\nWe will file visit: test1.txt - 1b\r\nWe will file visit: test2.txt - 2b\r\n"));
        }

        [Test]
        public void Reset_ShouldClearVisitedEntities()
        {
            // Arrange
            var file1 = new File("test1.txt", 1);

            // Act
            visitor.Visit(file1);
            visitor.Reset();
            visitor.Visit(file1);


            // Assert
            var output = Encoding.UTF8.GetString(outputStream.ToArray());
            Assert.That(output, Contains.Substring("We will file visit: test1.txt - 1b\r\nWe will file visit: test1.txt - 1b\r\n"));
        }
    }
}
