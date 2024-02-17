using DesignPatterns_HW3.Common;

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
            streamWriter.WriteLine($"Processing {message.FileName}");
        }
    } 
}
