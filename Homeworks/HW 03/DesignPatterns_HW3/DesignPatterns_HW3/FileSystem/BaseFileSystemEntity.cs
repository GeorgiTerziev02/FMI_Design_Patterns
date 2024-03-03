using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3.FileSystem
{
    public abstract class BaseFileSystemEntity : IFileSystemEntity
    {
        public BaseFileSystemEntity(string relativePath, ulong size)
        {
            RelativePath = relativePath;
            Size = size;
        }

        // Needed to add getters and setters to all props
        // because of the cycling detection...
        public string RelativePath { get; set; }

        public virtual ulong Size { get; set; }

        public abstract void Accept(IFileSystemEntityVisitor visitor);
    }
}
