using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3.FileSystem
{
    public class File : BaseFileSystemEntity
    {
        public File(string relativePath, ulong size) : base(relativePath, size)
        {
        }

        public override void Accept(IFileSystemEntityVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
