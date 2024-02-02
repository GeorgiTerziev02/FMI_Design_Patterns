using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.FileSystemProvider;

namespace DesignPatterns_HW3.Visitor
{
    public class HashStreamWriterVisitor : IFileSystemEntityVisitor
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

            // JORO: is this a relative path??
            using var stream = _fileSystemProvider.OpenFile(file.RelativePath, FileMode.Open);
            var checksum = _checksumCalculator.Calculate(stream);

            Console.WriteLine($"{file.RelativePath} - {checksum}");
        }

        public void Visit(Directory directory)
        {
            foreach (var file in directory.Children)
            {
                file.Accept(this);
            }
        }
    }
}
