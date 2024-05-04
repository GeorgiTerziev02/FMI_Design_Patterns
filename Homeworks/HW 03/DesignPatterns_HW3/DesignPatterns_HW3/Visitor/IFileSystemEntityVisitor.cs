namespace DesignPatterns_HW3.Visitor
{
    public interface IFileSystemEntityVisitor
    {
        void Visit(File file);
        
        void Visit(Directory directory);

        void Reset();
    }
}
