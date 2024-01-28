using DesignPatterns_HW3.FileSystem;
using DesignPatterns_HW3.FileSystemProvider;

using Directory = DesignPatterns_HW3.FileSystem.Directory;
using File = DesignPatterns_HW3.FileSystem.File;

namespace DesignPatterns_HW3.FileSystemBuilder
{
    // TODO: better name
    public class FileSystemNotFollowingShortcutBuilder : IFileSystemBuilder
    {
        private readonly IFileSystemProvider _fileSystemProvider;

        public FileSystemNotFollowingShortcutBuilder(
            IFileSystemProvider fileSystemProvider)
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
                var children = new List<IFileSystemEntity>();
                ulong directorySize = 0;
                foreach (var childPath in _fileSystemProvider.GetFileSystemEntries(path))
                {
                    var childEntity = Build(childPath);
                    directorySize += childEntity.Size;
                    children.Add(childEntity);
                }

                return new Directory(path, directorySize, children);
            }

            throw new ArgumentException($"Invalid path: {path}");
        }
    }
}
