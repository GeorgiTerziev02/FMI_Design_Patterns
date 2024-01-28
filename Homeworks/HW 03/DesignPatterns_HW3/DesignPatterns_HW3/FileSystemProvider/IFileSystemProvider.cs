namespace DesignPatterns_HW3.FileSystemProvider
{
    public interface IFileSystemProvider
    {
        bool IsFile(string path);

        bool IsDirectory(string path);

        IEnumerable<string> GetFileSystemEntries(string path);

        ulong GetFileSize(string path);
    }
}
