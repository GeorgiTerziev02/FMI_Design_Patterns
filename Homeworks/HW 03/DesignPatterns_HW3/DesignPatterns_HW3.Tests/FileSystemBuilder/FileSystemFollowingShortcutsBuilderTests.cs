using DesignPatterns_HW3.FileSystem;
using DesignPatterns_HW3.FileSystemBuilder;

namespace DesignPatterns_HW3.Tests.FileSystemBuilder
{
    [TestFixture]
    public class FileSystemFollowingShortcutsBuilderTests
    {
        private const string TEST_DIRECTORY_PATH = "..\\..\\..\\UnitTestFiles\\FileSystemBuilder\\";

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
                Assert.That(fileSystem.Size, Is.EqualTo(5359));
            });

            var directory = fileSystem as Directory;
            Assert.Multiple(() =>
            {
                Assert.That(directory!.Children, Has.Count.EqualTo(3));
                Assert.That(directory.Children.Any(x => x is Shortcut), Is.True);
            });

            var shortcut = directory!.Children
                .Where(x => x is Shortcut)
                .Select(x => x as Shortcut)
                .FirstOrDefault()!;
            var expectedShortcutTarget = directory!.Children
                .Where(x => x.RelativePath.EndsWith("file.txt"))
                .FirstOrDefault();
            Assert.Multiple(() =>
            {
                Assert.That(shortcut, Is.Not.Null);
                Assert.That(shortcut.Size, Is.EqualTo(2830));
                Assert.That(shortcut.Target, Is.Not.Null);
                Assert.That(shortcut.Target, Is.SameAs(expectedShortcutTarget));
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
                Assert.That(childDirectory.Children.Any(x => x is Shortcut), Is.True);
            });
        }
    }
}
