using DesignPatterns_HW3.FileSystem;
using DesignPatterns_HW3.Visitor;

using Moq;

namespace DesignPatterns_HW3.Tests.FileSystem
{
    [TestFixture]
    public class ShortcutTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            // Act
            var refFileSystemEntity = new File("f1", 1);
            var directory = new Shortcut("s1", 4, refFileSystemEntity);
            
            // Assert
            Assert.That(directory.RelativePath, Is.EqualTo("s1"));
            Assert.That(directory.Size, Is.EqualTo(4));
            Assert.That(directory.Target, Is.EqualTo(refFileSystemEntity));
        }

        [Test]
        public void Accept_ShouldCallVisitorWithTarget()
        {
            // Arrange
            var visitor = new Mock<IFileSystemEntityVisitor>();
            var refFileSystemEntity = new File("f1", 1);
            var file = new Shortcut("s1", 4, refFileSystemEntity);

            // Act
            file.Accept(visitor.Object);

            // Assert
            visitor.Verify(x => x.Visit(refFileSystemEntity), Times.Once);
        }
    }
}
