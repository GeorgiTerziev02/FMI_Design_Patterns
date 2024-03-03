using System.Diagnostics;

using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.Common;
using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3.Observer
{
    public interface IProgressReporter : IObserver
    {
        void StartTimer(ulong expectedTotalBytes);

        ulong EndTimer();
    }

    public class ProgressReporter : BaseStreamWriter, IProgressReporter
    {
        private Stopwatch _stopwatch = new Stopwatch();
        private ulong _expectedBytesToRead = 0;
        private ulong _readBytes = 0;

        public ProgressReporter(Stream outputStream) : base(outputStream)
        { }

        public ulong EndTimer()
        {
            _stopwatch.Stop();
            return (ulong)_stopwatch.ElapsedMilliseconds / 1000;
        }

        public void StartTimer(ulong expectedTotalBytes)
        {
            _expectedBytesToRead = expectedTotalBytes;
            _readBytes = 0;
            _stopwatch.Start();
        }

        public void Update(IObservable sender, FileMessage message)
        {
            if (sender is IChecksumCalculator)
            {
                // TODO: total from file and chunk for the percentage
                streamWriter.Write($"\rProcessing {message.FileName} - {message.Size}b");
                _readBytes += message.Size;
                PrintPercentage();
            }
            else if(sender is HashStreamWriterVisitor)
            {
                streamWriter.WriteLine($"Processing {message.FileName} - with length {message.Size}b");
                PrintPercentage();
            }
            else
            {
                throw new ArgumentException("Invalid sender type");
            }
        }

        private void PrintPercentage()
        {
            var percentage = (double)_readBytes / (double)_expectedBytesToRead * 100;
            streamWriter.Write($" Percentage of all {percentage:F2}%");
        }
    } 
}
