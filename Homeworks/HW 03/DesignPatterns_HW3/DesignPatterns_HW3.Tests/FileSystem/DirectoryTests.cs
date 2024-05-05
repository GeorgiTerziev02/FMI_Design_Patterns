using DesignPatterns_HW3.FileSystem;
using DesignPatterns_HW3.Visitor;

using Moq;

namespace DesignPatterns_HW3.Tests.FileSystem
{
    [TestFixture]
    public class DirectoryTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            // Act
            var directory = new Directory("dir1", 0, []);

            // Assert
            Assert.That(directory.RelativePath, Is.EqualTo("dir1"));
            Assert.That(directory.Size, Is.EqualTo(0));
            Assert.That(directory.Children, Is.Not.Null);
            Assert.That(directory.Children, Is.Empty);
        }

        [Test]
        public void AddChild_ShouldAddChildAndIncrementCount()
        {
            // Arrange
            var directory = new Directory("dir1", 0, new List<IFileSystemEntity>());
            Assert.That(directory.Children, Is.Empty);
            Assert.That(directory.Size, Is.EqualTo(0));
            var file = new File("file1.txt", 10);

            // Act
            directory.AddChild(file);

            // Assert
            Assert.That(directory.Size, Is.EqualTo(10));
            Assert.That(directory.Children, Has.Count.EqualTo(1));
            Assert.That(directory.Children, Has.Member(file));
        }


        [Test]
        public void Accept_ShouldCallVisitor()
        {
            // Arrange
            var file1 = new File("file1.txt", 10);
            var file2 = new File("file2.txt", 20);
            var directory = new Directory("dir1", 0, []);
            directory.Children.Add(file1);
            directory.Children.Add(file2);
            var visitor = new Mock<IFileSystemEntityVisitor>();
            // Act
            directory.Accept(visitor.Object);
            // Assert
            visitor.Verify(v => v.Visit(directory), Times.Once);
        }
    }
}
