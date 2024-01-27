using DesignPatterns_HW3.FileSystem;

namespace DesignPatterns_HW3.FileSystemBuilder
{
    // TODO: better name
    // TODO: make it recognise both symlinks and shortcuts
    public class FileSystemFollowingShortcutsBuilder : IFileSystemBuilder
    {
        private HashSet<string> _visitedPaths = new HashSet<string>();

        public IFileSystemEntity Build(string path)
        {
            throw new NotImplementedException();
        }
    }
}
