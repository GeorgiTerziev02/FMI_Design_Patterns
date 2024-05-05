namespace DesignPatterns_HW3.Tests.FileSystemProvider
{
    [TestFixture]
    public class FileSystemProviderTests
    {
        private const string TEST_DIRECTORY_PATH = "..\\..\\..\\UnitTestFiles\\FileSystemProvider\\";
        private DesignPatterns_HW3.FileSystemProvider.FileSystemProvider fileSystemProvider;

        [SetUp]
        public void SetUp()
        {
            fileSystemProvider = new DesignPatterns_HW3.FileSystemProvider.FileSystemProvider();
        }

        [Test]
        public void GetFileSize_ShouldReturnFileSize()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "file.txt";

            // Act
            var result = fileSystemProvider.GetFileSize(path);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void GetFileSystemEntries_WhenDirectoryExists_ShouldReturnEntries()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "Directory";

            // Act
            var result = fileSystemProvider.GetFileSystemEntries(path);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result, Contains.Item(TEST_DIRECTORY_PATH + "Directory\\f1.txt"));
            Assert.That(result, Contains.Item(TEST_DIRECTORY_PATH + "Directory\\f2.txt"));
        }

        [Test]
        public void IsFile_WhenFileExistsShouldReturnTrue()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "file.txt";

            // Act
            var result = fileSystemProvider.IsFile(path);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsFile_WhenDirectoryPathIsProvidedShouldReturnFalse()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "Directory";

            // Act
            var result = fileSystemProvider.IsFile(path);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsDirectory_WhenDirectoryExistsShouldReturnTrue()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "Directory";

            // Act
            var result = fileSystemProvider.IsDirectory(path);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsDirectory_WhenFilePathProvidedShouldReturnFalse()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "file.txt";

            // Act
            var result = fileSystemProvider.IsDirectory(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void OpenFile_WhenFileExistsShouldReturnFileStream()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "file.txt";

            // Act
            var result = fileSystemProvider.OpenFile(path, FileMode.Open);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.CanRead, Is.True);
        }

        [Test]
        public void IsShortcut_WhenShortcutExistsShouldReturnTrue()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "shortcut.lnk";

            // Act
            var result = fileSystemProvider.IsShortcut(path, out var target);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(target, Is.EqualTo(TEST_DIRECTORY_PATH + "file.txt"));
        }

        [Test]
        public void IsShortcut_WhenShortcutDoesNotExistShouldReturnFalse()
        {
            // Arrange
            var path = TEST_DIRECTORY_PATH + "file.txt";

            // Act
            var result = fileSystemProvider.IsShortcut(path, out var target);

            // Assert
            Assert.That(result, Is.False);
            Assert.That(target, Is.EqualTo(""));
        }
    }
}
