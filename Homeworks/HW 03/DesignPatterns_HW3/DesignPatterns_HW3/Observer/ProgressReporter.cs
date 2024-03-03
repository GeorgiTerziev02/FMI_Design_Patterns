using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.Common;
using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3.Observer
{
    public interface IProgressReporter : IObserver
    {

    }

    public class ProgressReporter : BaseStreamWriter, IProgressReporter
    {
        public ProgressReporter(Stream outputStream) : base(outputStream)
        { }

        public void Update(IObservable sender, FileMessage message)
        {
            if(sender is IChecksumCalculator)
            {
                streamWriter.WriteLine($"Processing {message.FileName} - {message.Size}b");
            }
            else if(sender is HashStreamWriterVisitor)
            {
                streamWriter.WriteLine($"Processing {message.FileName}");
            }
            else
            {
                throw new ArgumentException("Invalid sender type");
            }
        }
    } 
}
