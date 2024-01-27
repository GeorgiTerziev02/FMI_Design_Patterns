namespace DesignPatterns_HW3.FileSystem
{
    public interface IFileSystemEntity
    {
        string RelativePath { get; }

        string Checksum { get; }
    }
}
