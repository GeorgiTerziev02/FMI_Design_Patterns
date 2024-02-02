using File = DesignPatterns_HW3.FileSystem.File;
using Directory = DesignPatterns_HW3.FileSystem.Directory;

namespace DesignPatterns_HW3.Visitor
{
    public class ReportWriterVisitor : IFileSystemEntityVisitor
    {
        public void Visit(File file)
        {
            Console.WriteLine($"We will file visit: {file.RelativePath} - {file.Size}kb");
        }

        public void Visit(Directory directory)
        {
            Console.WriteLine($"We will visit path: {directory.RelativePath} - {directory.Size}kb");

            foreach (var file in directory.Children)
            {
                file.Accept(this);
            }
        }
    }
}
