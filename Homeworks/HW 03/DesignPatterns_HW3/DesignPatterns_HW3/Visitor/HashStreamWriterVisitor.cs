using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.Common;
using DesignPatterns_HW3.FileSystem;
using DesignPatterns_HW3.FileSystemProvider;
using DesignPatterns_HW3.Observer;

namespace DesignPatterns_HW3.Visitor
{
    public class Snapshot
    {
        public Snapshot(IEnumerable<string> visited, IFileSystemEntity root)
        {
            Visited = visited.ToHashSet();
            Root = root;
        }

        public HashSet<string> Visited { get; }

        public IFileSystemEntity Root { get; }
    }

    public class HashStreamWriterVisitor : BaseObservableStreamWriter, IFileSystemEntityVisitor
    {
        // No multiple inheritance
        private readonly HashSet<string> _visitedEntities = new();
        private readonly IChecksumCalculator _checksumCalculator;
        private readonly IFileSystemProvider _fileSystemProvider;

        public HashStreamWriterVisitor(
            Stream outputStream,
            IChecksumCalculator checksumCalculator,
            IFileSystemProvider fileSystemProvider
            ) : base(outputStream) 
        {
            _checksumCalculator = checksumCalculator;
            _fileSystemProvider = fileSystemProvider;
        }

        public override void Attach(IObserver observer)
        {
            _checksumCalculator.Attach(observer);
            base.Attach(observer);
        }

        public void Visit(File file)
        {
            if (_visitedEntities.Contains(file.RelativePath))
            {
                return;
            }

            _visitedEntities.Add(file.RelativePath);
            // TODO: Implement
            // _checksumCalculator.Calculate(file);

            Notify(this, new FileMessage(file.RelativePath, file.Size));
            // JORO: is this a relative path??
            try
            {
                using var stream = _fileSystemProvider.OpenFile(file.RelativePath, FileMode.Open);
                var checksum = _checksumCalculator.Calculate(stream);
                streamWriter.WriteLine($"\rChecksum - {checksum}");
            }
            catch (Exception)
            {
                streamWriter.WriteLine("Error accessing file");
            }
        }

        public void Visit(Directory directory)
        {
            if (_visitedEntities.Contains(directory.RelativePath))
            {
                return;
            }

            _visitedEntities.Add(directory.RelativePath);

            Notify(this, new FileMessage(directory.RelativePath, directory.Size));
            foreach (var file in directory.Children)
            {
                file.Accept(this);
            }
        }
    }
}
