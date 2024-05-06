using DesignPatterns_HW3.FileSystem;
using DesignPatterns_HW3.FileSystemBuilder;

namespace DesignPatterns_HW3.Tests.FileSystemBuilder
{
    [TestFixture]
    public class FileSystemFollowingShortcutsBuilderTests
    {
        private const string TEST_DIRECTORY_PATH = "..\\..\\..\\Resources\\Files\\FileSystemBuilder\\";

        private FileSystemFollowingShortcutsBuilder fileSystemFollowingShortcutsBuilder;

        [SetUp]
        public void Setup()
        {
            // This is actually not a unit test, but an integration test :(
            // Using real fileSystemProvider because it is easier to test, the folder has already been set up with the mock files
            var fileSystemProvider = new DesignPatterns_HW3.FileSystemProvider.FileSystemProvider();
            fileSystemFollowingShortcutsBuilder = new FileSystemFollowingShortcutsBuilder(fileSystemProvider);
        }

        [Test]
        public void Build_BuildsFileSystemWithShortcuts()
        {
            // Arrange
            // Act
            var fileSystem = fileSystemFollowingShortcutsBuilder.Build(TEST_DIRECTORY_PATH);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(fileSystem, Is.Not.Null);
                Assert.That(fileSystem, Is.InstanceOf<Directory>());
                Assert.That(fileSystem.RelativePath, Is.EqualTo(TEST_DIRECTORY_PATH));
                Assert.That(fileSystem.Size, Is.EqualTo(5519));
            });

            var directory = fileSystem as Directory;
            Assert.Multiple(() =>
            {
                Assert.That(directory!.Children, Has.Count.EqualTo(3));
                Assert.That(directory.Children.Any(x => x is Shortcut), Is.True);
            });

            var fileShortcut = directory!.Children
                .Where(x => x is Shortcut)
                .Select(x => x as Shortcut)
                .FirstOrDefault()!;
            var expectedFileShortcutTarget = directory!.Children
                .Where(x => x.RelativePath.EndsWith("file.txt"))
                .FirstOrDefault();
            Assert.Multiple(() =>
            {
                Assert.That(fileShortcut, Is.Not.Null);
                Assert.That(fileShortcut.Size, Is.EqualTo(2912));
                Assert.That(fileShortcut.Target, Is.Not.Null);
                Assert.That(fileShortcut.Target, Is.SameAs(expectedFileShortcutTarget));
            });

            Directory childDirectory = directory!.Children
                .Where(x => x is Directory)
                .Select(x => x as Directory)
                .FirstOrDefault()!;
            Assert.Multiple(() =>
            {
                Assert.That(childDirectory, Is.Not.Null);
                Assert.That(childDirectory.Size, Is.EqualTo(2604));
                Assert.That(childDirectory.Children, Has.Count.EqualTo(3));
                Assert.That(childDirectory.Children.Any(x => x is Shortcut), Is.True);
            });

            var directoryShortcut = childDirectory!.Children
                .Where(x => x is Shortcut)
                .Select(x => x as Shortcut)
                .FirstOrDefault()!;

            Assert.That(directoryShortcut.Target, Is.SameAs(childDirectory));
        }

        [Test]
        public void Build_ShouldReturnInstanceOfFile()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "file.txt";

            // Act
            var fileSystem = fileSystemFollowingShortcutsBuilder.Build(path);

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
        public void Build_ShouldReturnInstanceOfShortcut()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "file-shortcut.lnk";

            // Act
            var fileSystem = fileSystemFollowingShortcutsBuilder.Build(path);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(fileSystem, Is.Not.Null);
                Assert.That(fileSystem, Is.InstanceOf<Shortcut>());
                Assert.That(fileSystem.RelativePath, Is.EqualTo(path));
                Assert.That(fileSystem.Size, Is.EqualTo(2912));
                
                var shortcut = fileSystem as Shortcut;
                Assert.That(shortcut!.Size, Is.EqualTo(2912));
                Assert.That(shortcut.Target, Is.Not.Null);
                Assert.That(shortcut.Target, Is.InstanceOf<File>());
            });
        }

        [Test]
        public void Build_ShouldThrowArgumentExceptionWhenPathIsInvalid()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "invalidPath";

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => fileSystemFollowingShortcutsBuilder.Build(path));
        }
    }
}
