namespace DesignPatterns_HW3.Visitor
{
    public class ReportWriterVisitor : IFileSystemEntityVisitor
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
