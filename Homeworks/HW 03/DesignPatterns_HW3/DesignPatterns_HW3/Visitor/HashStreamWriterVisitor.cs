using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.FileSystemProvider;
using DesignPatterns_HW3.Observer;

namespace DesignPatterns_HW3.Visitor
{
    public class HashStreamWriterVisitor : Observable, IFileSystemEntityVisitor
    {
        private readonly IChecksumCalculator _checksumCalculator;
        private readonly IFileSystemProvider _fileSystemProvider;

        public HashStreamWriterVisitor(
            IChecksumCalculator checksumCalculator,
            IFileSystemProvider fileSystemProvider)
        {
            _checksumCalculator = checksumCalculator;
            _fileSystemProvider = fileSystemProvider;
        }

        public void Visit(File file)
        {
            // TODO: Implement
            // _checksumCalculator.Calculate(file);

            Notify(this, new FileMessage(file.RelativePath, file.Size));
            // JORO: is this a relative path??
            using var stream = _fileSystemProvider.OpenFile(file.RelativePath, FileMode.Open);
            var checksum = _checksumCalculator.Calculate(stream);
        }

        public void Visit(Directory directory)
        {
            Notify(this, new FileMessage(directory.RelativePath, directory.Size));
            foreach (var file in directory.Children)
            {
                file.Accept(this);
            }
        }
    }
}
