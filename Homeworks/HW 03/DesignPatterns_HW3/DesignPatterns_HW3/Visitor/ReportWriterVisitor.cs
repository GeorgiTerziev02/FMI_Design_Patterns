using DesignPatterns_HW3.Common;

namespace DesignPatterns_HW3.Visitor
{
    public class ReportWriterVisitor : BaseStreamWriter, IFileSystemEntityVisitor
    {
        public ReportWriterVisitor(Stream outputStream) : base(outputStream)
        { }

        public void Visit(File file)
        {
            streamWriter.WriteLine($"We will file visit: {file.RelativePath} - {file.Size}b");
        }

        public void Visit(Directory directory)
        {
            streamWriter.WriteLine($"We will file visit: {directory.RelativePath} - {directory.Size}b");

            foreach (var file in directory.Children)
            {
                file.Accept(this);
            }
        }
    }
}
