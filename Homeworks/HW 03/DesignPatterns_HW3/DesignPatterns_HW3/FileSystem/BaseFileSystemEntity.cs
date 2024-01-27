namespace DesignPatterns_HW3.FileSystem
{
    public abstract class BaseFileSystemEntity : IFileSystemEntity
    {
        public BaseFileSystemEntity(string relativePath)
        {
            RelativePath = relativePath;
            // TODO: Implement checksum calculation
            Checksum = "";
        }

        public string RelativePath { get; }

        public string Checksum { get; }
    }
}
