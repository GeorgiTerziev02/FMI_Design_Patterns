using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3.FileSystem
{
    public class Shortcut : BaseFileSystemEntity
    {
        public Shortcut(string relativePath, ulong size, IFileSystemEntity target)
            : base(relativePath, size)
        {
            Target = target;
        }

        public IFileSystemEntity Target { get; set; }

        // Bad design, but this kind of entity should not be visited
        public override void Accept(IFileSystemEntityVisitor visitor)
        {
            Target.Accept(visitor);
        }
    }
}
