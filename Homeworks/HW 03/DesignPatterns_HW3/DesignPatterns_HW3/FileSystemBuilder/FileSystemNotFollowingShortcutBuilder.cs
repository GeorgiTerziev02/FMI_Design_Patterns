using DesignPatterns_HW3.FileSystem;

using FileSystemFile = System.IO.File;
using FileSystemDirectory = System.IO.Directory;
using File = DesignPatterns_HW3.FileSystem.File;
using Directory = DesignPatterns_HW3.FileSystem.Directory;

namespace DesignPatterns_HW3.FileSystemBuilder
{
    // TODO: better name
    public class FileSystemNotFollowingShortcutBuilder : IFileSystemBuilder
    {
        public IFileSystemEntity Build(string path)
        {
            if (FileSystemFile.Exists(path))
            {
                return new File(path);
            }

            if(FileSystemDirectory.Exists(path))
            {
                var children = new List<IFileSystemEntity>();
                foreach (var childPath in FileSystemDirectory.EnumerateFileSystemEntries(path))
                {
                    children.Add(Build(childPath));
                }

                return new Directory(path, children);
            }

            throw new ArgumentException($"Invalid path: {path}");
        }
    }
}
