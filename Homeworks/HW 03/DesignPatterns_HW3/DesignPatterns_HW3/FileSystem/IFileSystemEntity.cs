using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3.FileSystem
{
    public interface IFileSystemEntity
    {
        string RelativePath { get; }

        ulong Size  { get; }

        void Accept(IFileSystemEntityVisitor visitor);
    }
}
