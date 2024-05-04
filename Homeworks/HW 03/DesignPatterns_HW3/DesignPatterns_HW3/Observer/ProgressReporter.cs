using System.Diagnostics;

using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.Common;
using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3.Observer
{
    public interface IProgressReporter : IObserver
    {
        void StartTimer(ulong expectedTotalBytes);

        long EndTimer();
    }

    public class ProgressReporter : BaseStreamWriter, IProgressReporter
    {
        private Stopwatch _stopwatch = new Stopwatch();
        private ulong _expectedBytesToRead = 0;
        private ulong _readBytes = 0;

        public ProgressReporter(Stream outputStream) : base(outputStream)
        { }

        /// <summary>
        /// Stops the timer
        /// </summary>
        /// <returns>Returns taken seconds</returns>
        public long EndTimer()
        {
            _stopwatch.Stop();
            return _stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Starts the timer
        /// </summary>
        /// <param name="expectedTotalBytes">Bytes to process</param>
        public void StartTimer(ulong expectedTotalBytes)
        {
            _expectedBytesToRead = expectedTotalBytes;
            _readBytes = 0;
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        public void Update(IObservable sender, FileMessage message)
        {
            if (sender is IChecksumCalculator)
            {
                _readBytes += message.Size;
                streamWriter.Write($"\rProcessing {message.Size}b, total processed {_readBytes}b");
                PrintPercentage();
            }
            else if(sender is HashStreamWriterVisitor)
            {
                streamWriter.WriteLine($"Processing {message.FileName} - with length {message.Size}b");
            }
            else
            {
                throw new ArgumentException("Invalid sender type");
            }
        }

        private void PrintPercentage()
        {
            var percentage = (double)_readBytes / (double)_expectedBytesToRead * 100;
            var remainingTime = _stopwatch.ElapsedMilliseconds / percentage * (100 - percentage);
            streamWriter.Write($" Total processed {percentage:F6}%, remaining time {remainingTime:F0}ms");
        }
    } 
}
