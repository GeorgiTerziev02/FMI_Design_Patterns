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

        public string RelativePath { get; }

        public ulong Size { get; }

        public abstract void Accept(IFileSystemEntityVisitor visitor);
    }
}
