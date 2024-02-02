using SystemFile = System.IO.File;
using SystemDirectory = System.IO.Directory;


namespace DesignPatterns_HW3.FileSystemProvider
{
    public class FileSystemProvider : IFileSystemProvider
    {
        public ulong GetFileSize(string path)
        {
            // TODO: maybe unify with the is file flag
            return (ulong)new FileInfo(path).Length;
        }

        public IEnumerable<string> GetFileSystemEntries(string path)
        {
            return SystemDirectory.EnumerateFileSystemEntries(path);
        }

        public bool IsDirectory(string path)
        {
            return SystemDirectory.Exists(path);
        }

        public bool IsFile(string path)
        {
            return SystemFile.Exists(path);
        }
    }
}
