using System.Linq;
using System.Text;

using DesignPatterns_HW3.FileSystem;
using DesignPatterns_HW3.FileSystemProvider;

namespace DesignPatterns_HW3.FileSystemBuilder
{

    // TODO: better name
    // TODO: make it recognise both symlinks and shortcuts
    public class FileSystemFollowingShortcutsBuilder : IFileSystemBuilder
    {
        private Dictionary<string, IFileSystemEntity> _visitedSystemEntities = new Dictionary<string, IFileSystemEntity>();

        private readonly IFileSystemProvider _fileSystemProvider;

        public FileSystemFollowingShortcutsBuilder(IFileSystemProvider fileSystemProvider)
        {
            _fileSystemProvider = fileSystemProvider;
        }

        public IFileSystemEntity Build(string path)
        {
            if (_visitedSystemEntities.TryGetValue(path, out var entity))
            {
                return entity;
            }

            if (_fileSystemProvider.IsFile(path))
            {
                if (_fileSystemProvider.IsShortcut(path, out var targetPath))
                {
                    var shortcut = new Shortcut(path, null) ;
                    _visitedSystemEntities.Add(path, new Shortcut(path, shortcut));
                    shortcut.Target = Build(targetPath);
                    return shortcut;
                }

                var fileSize = _fileSystemProvider.GetFileSize(path);
                return AddToVisitedAndReturn(new File(path, fileSize));
            }

            if (_fileSystemProvider.IsDirectory(path))
            {
                var directory = new Directory(path, 0, new List<IFileSystemEntity>());
                _visitedSystemEntities.Add(path, directory);
                foreach (var childPath in _fileSystemProvider.GetFileSystemEntries(path))
                {
                    var childEntity = Build(childPath);
                    directory.Size += childEntity.Size;
                    directory.Children.Add(childEntity);
                }

                return directory;
            }

            throw new ArgumentException($"Invalid path: {path}");
        }

        private IFileSystemEntity AddToVisitedAndReturn(IFileSystemEntity entity)
        {
            _visitedSystemEntities.Add(entity.RelativePath, entity);
            return entity;
        }
    }
}
