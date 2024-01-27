namespace DesignPatterns_HW3.FileSystem
{
    public class Directory : BaseFileSystemEntity
    {
        public Directory(string relativePath, ICollection<IFileSystemEntity> children)
            : base(relativePath)
        {
            Children = children;
        }

        public ICollection<IFileSystemEntity> Children { get; }
    }
}
