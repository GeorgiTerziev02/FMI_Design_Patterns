using DesignPatterns_HW3.FileSystem;

namespace DesignPatterns_HW3.FileSystemBuilder
{
    public interface IFileSystemBuilder
    {
        IFileSystemEntity Build(string path);
    }
}
