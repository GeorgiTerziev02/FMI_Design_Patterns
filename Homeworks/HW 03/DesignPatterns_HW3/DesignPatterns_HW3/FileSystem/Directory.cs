using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3.FileSystem
{
    public class Directory : BaseFileSystemEntity
    {
        public Directory(string relativePath, ulong size, ICollection<IFileSystemEntity> children)
            : base(relativePath, size)
        {
            Children = children;
        }

        public ICollection<IFileSystemEntity> Children { get; private set; }

        public void AddChild(IFileSystemEntity child)
        {
            Size += child.Size;
            Children.Add(child);
        }

        public override void Accept(IFileSystemEntityVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
