﻿using DesignPatterns_HW3.FileSystem;
using DesignPatterns_HW3.FileSystemProvider;

namespace DesignPatterns_HW3.FileSystemBuilder
{
    // TODO: make it recognise both symlinks and shortcuts
    public class FileSystemFollowingShortcutsBuilder : IFileSystemBuilder
    {
        private readonly Dictionary<string, IFileSystemEntity> _visitedSystemEntities = [];

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
                var fileSize = _fileSystemProvider.GetFileSize(path);
                if (_fileSystemProvider.IsShortcut(path, out var targetPath))
                {
                    var shortcut = new Shortcut(path, fileSize, null);
                    _visitedSystemEntities.Add(path, shortcut);
                    shortcut.Target = Build(targetPath);
                    return shortcut;
                }

                return AddToVisitedAndReturn(new File(path, fileSize));
            }

            if (_fileSystemProvider.IsDirectory(path))
            {
                var directory = new Directory(path, 0, []);
                _visitedSystemEntities.Add(path, directory);
                foreach (var childPath in _fileSystemProvider.GetFileSystemEntries(path))
                {
                    var childEntity = Build(childPath);
                    directory.AddChild(childEntity);
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
