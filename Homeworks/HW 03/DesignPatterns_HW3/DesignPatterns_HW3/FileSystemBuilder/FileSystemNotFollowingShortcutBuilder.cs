using DesignPatterns_HW3.FileSystem;
using DesignPatterns_HW3.FileSystemProvider;

namespace DesignPatterns_HW3.FileSystemBuilder
{
    public class FileSystemNotFollowingShortcutBuilder : IFileSystemBuilder
    {
        private readonly IFileSystemProvider _fileSystemProvider;

        public FileSystemNotFollowingShortcutBuilder(IFileSystemProvider fileSystemProvider)
        {
            _fileSystemProvider = fileSystemProvider;
        }

        public IFileSystemEntity Build(string path)
        {
            if (_fileSystemProvider.IsFile(path))
            {
                var fileSize = _fileSystemProvider.GetFileSize(path);
                return new File(path, fileSize);
            }

            if(_fileSystemProvider.IsDirectory(path))
            {
                var directory = new Directory(path, 0, new List<IFileSystemEntity>());
                foreach (var childPath in _fileSystemProvider.GetFileSystemEntries(path))
                {
                    var childEntity = Build(childPath);
                    directory.AddChild(childEntity);
                }

                return directory;
            }

            throw new ArgumentException($"Invalid path: {path}");
        }
    }
}
