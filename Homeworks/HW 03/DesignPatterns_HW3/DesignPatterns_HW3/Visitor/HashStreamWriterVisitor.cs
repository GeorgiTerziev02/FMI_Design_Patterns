namespace DesignPatterns_HW3.Visitor
{
    public class FileSystemEntityVisitor : IFileSystemEntityVisitor
    {
        public void Visit(FileSystem.File file)
        {
            throw new NotImplementedException();
        }

        public void Visit(FileSystem.Directory directory)
        {
            throw new NotImplementedException();
        }
    }
}
