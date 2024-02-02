using Directory = DesignPatterns_HW3.FileSystem.Directory;
using File = DesignPatterns_HW3.FileSystem.File;

namespace DesignPatterns_HW3.Visitor
{
    public interface IFileSystemEntityVisitor
    {
        void Visit(File file);
        
        void Visit(Directory directory);
    }
}
