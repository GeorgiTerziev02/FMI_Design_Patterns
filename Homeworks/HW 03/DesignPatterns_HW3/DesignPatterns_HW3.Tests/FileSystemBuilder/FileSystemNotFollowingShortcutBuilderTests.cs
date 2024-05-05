using DesignPatterns_HW3.FileSystem;
using DesignPatterns_HW3.FileSystemBuilder;

namespace DesignPatterns_HW3.Tests.FileSystemBuilder
{
    [TestFixture]
    public class FileSystemNotFollowingShortcutBuilderTests
    {
        private const string TEST_DIRECTORY_PATH = "..\\..\\..\\UnitTestFiles\\FileSystemBuilder\\";

        private FileSystemNotFollowingShortcutBuilder fileSystemNotFollowingShortcutBuilder;

        [SetUp]
        public void Setup()
        {
            // This is actually not a unit test, but an integration test :(
            // Using real fileSystemProvider because it is easier to test, the folder has already been set up with the mock files
            var fileSystemProvider = new DesignPatterns_HW3.FileSystemProvider.FileSystemProvider();
            fileSystemNotFollowingShortcutBuilder = new FileSystemNotFollowingShortcutBuilder(fileSystemProvider);
        }

        [Test]
        public void Build_BuildsFileSystemWithoutShortcuts()
        {
            // Arrange
            // Act
            var fileSystem = fileSystemNotFollowingShortcutBuilder.Build(TEST_DIRECTORY_PATH);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(fileSystem, Is.Not.Null);
                Assert.That(fileSystem, Is.InstanceOf<Directory>());
                Assert.That(fileSystem.RelativePath, Is.EqualTo(TEST_DIRECTORY_PATH));
                Assert.That(fileSystem.Size, Is.EqualTo(5370));
            });

            var directory = fileSystem as Directory;
            Assert.Multiple(() =>
            {
                Assert.That(directory!.Children, Has.Count.EqualTo(3));
                Assert.That(directory.Children.Any(x => x is Shortcut), Is.False);
            });

            Directory childDirectory = directory!.Children
                .Where(x => x is Directory)
                .Select(x => x as Directory)
                .FirstOrDefault()!;
            Assert.Multiple(() =>
            {
                Assert.That(childDirectory, Is.Not.Null);
                Assert.That(childDirectory.Size, Is.EqualTo(2526));
                Assert.That(childDirectory.Children, Has.Count.EqualTo(3));
                Assert.That(childDirectory.Children.Any(x => x is Shortcut), Is.False);
            });
        }

        [Test]
        public void Build_ShouldReturnInstanceOfFile()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "file.txt";

            // Act
            var fileSystem = fileSystemNotFollowingShortcutBuilder.Build(path);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(fileSystem, Is.Not.Null);
                Assert.That(fileSystem, Is.InstanceOf<File>());
                Assert.That(fileSystem.RelativePath, Is.EqualTo(path));
                Assert.That(fileSystem.Size, Is.EqualTo(3));
            });
        }

        [Test]
        public void Build_ShouldThrowArgumentExceptionWhenPathIsInvalid()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "invalid.txt";

            // Act
            void Build() => fileSystemNotFollowingShortcutBuilder.Build(path);

            // Assert
            Assert.That(Build, Throws.ArgumentException);
        }
    }
}
