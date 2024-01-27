namespace DesignPatterns_HW3.FileSystem
{
    public class Directory : IFileSystemEntity
    {
        public IEnumerable<IFileSystemEntity> Children { get; set; } = new List<IFileSystemEntity>();
    }
}
