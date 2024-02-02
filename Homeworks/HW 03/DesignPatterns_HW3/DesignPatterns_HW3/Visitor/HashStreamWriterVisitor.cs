using DesignPatterns_HW3.ChecksuCalculator;

namespace DesignPatterns_HW3.Visitor
{
    public class HashStreamWriterVisitor : IFileSystemEntityVisitor
    {
        private readonly IChecksumCalculator _checksumCalculator;

        public HashStreamWriterVisitor(IChecksumCalculator checksumCalculator)
        {
            _checksumCalculator = checksumCalculator;
        }

        public void Visit(File file)
        {
            // TODO: Implement
            // _checksumCalculator.Calculate(file);
        }

        public void Visit(Directory directory)
        {
            throw new NotImplementedException();
        }
    }
}
