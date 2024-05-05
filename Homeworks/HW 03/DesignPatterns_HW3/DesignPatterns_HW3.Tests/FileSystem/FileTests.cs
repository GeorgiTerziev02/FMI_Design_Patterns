using DesignPatterns_HW3.Visitor;

using Moq;

namespace DesignPatterns_HW3.Tests.FileSystem
{
    [TestFixture]
    public class FileTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            // Act
            var directory = new File("f1", 1);

            // Assert
            Assert.That(directory.RelativePath, Is.EqualTo("f1"));
            Assert.That(directory.Size, Is.EqualTo(1));
        }

        [Test]
        public void Accept_ShouldCallVisitor()
        {
            // Arrange
            var visitor = new Mock<IFileSystemEntityVisitor>();
            var file = new File("f1", 1);

            // Act
            file.Accept(visitor.Object);

            // Assert
            visitor.Verify(x => x.Visit(file), Times.Once);
        }
    }
}
