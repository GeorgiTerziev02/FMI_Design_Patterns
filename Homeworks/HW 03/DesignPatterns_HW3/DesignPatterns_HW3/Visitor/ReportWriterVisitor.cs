using DesignPatterns_HW3.Common;

namespace DesignPatterns_HW3.Visitor
{
    public class ReportWriterVisitor : BaseStreamWriter, IFileSystemEntityVisitor
    {
        // No multiple inheritance
        private readonly HashSet<string> _visitedEntities = new();

        public ReportWriterVisitor(Stream outputStream) : base(outputStream)
        { }

        public ulong TotalBytesToVisit { get; set; }

        public void Visit(File file)
        {
            if (_visitedEntities.Contains(file.RelativePath))
            {
                return;
            }

            _visitedEntities.Add(file.RelativePath);

            streamWriter.WriteLine($"We will file visit: {file.RelativePath} - {file.Size}b");
        }

        public void Visit(Directory directory)
        {
            if (_visitedEntities.Contains(directory.RelativePath))
            {
                return;
            }

            _visitedEntities.Add(directory.RelativePath);

            streamWriter.WriteLine($"We will file visit: {directory.RelativePath} - {directory.Size}b");

            foreach (var file in directory.Children)
            {
                file.Accept(this);
            }
        }
    }
}
