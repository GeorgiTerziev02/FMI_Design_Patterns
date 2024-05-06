using System.Diagnostics;

using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.Common;
using DesignPatterns_HW3.Observer;
using DesignPatterns_HW3.Reporter.Memento;
using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3.Reporter
{
    public class ProgressReporter : BaseStreamWriter, IProgressReporterMemento
    {
        private readonly Stopwatch _stopwatch = new();
        // Need to store the initial time to calculate the total time
        // Because we can't set start time of the stopwatch
        private long _initialElapsedMilliseconds = 0;
        private ulong _expectedBytesToRead = 0;
        private ulong _readBytes = 0;

        public ProgressReporter(Stream outputStream) : base(outputStream)
        { }

        public bool Stopped => !_stopwatch.IsRunning;

        public long ElapsedMilliseconds => _stopwatch.ElapsedMilliseconds + _initialElapsedMilliseconds;

        /// <summary>
        /// Stops the timer
        /// </summary>
        /// <returns>Returns taken seconds</returns>
        public long EndTimer()
        {
            _stopwatch.Stop();
            return ElapsedMilliseconds;
        }

        public ProgressSnapshot GetSnapshot()
        {
            return new ProgressSnapshot(_readBytes, _expectedBytesToRead, ElapsedMilliseconds);
        }

        public void Pause()
        {
            _stopwatch.Stop();
        }

        public void Restore(ProgressSnapshot snapshot)
        {
            _expectedBytesToRead = snapshot.ExpectedBytesToRead;
            _readBytes = snapshot.ReadBytes;
            _initialElapsedMilliseconds = snapshot.ElapsedMilliseconds;
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        /// <summary>
        /// Starts the timer
        /// </summary>
        /// <param name="expectedTotalBytes">Bytes to process</param>
        public void StartTimer(ulong expectedTotalBytes)
        {
            _expectedBytesToRead = expectedTotalBytes;
            _readBytes = 0;
            _initialElapsedMilliseconds = 0;
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        public void Update(IObservable sender, FileMessage message)
        {
            if (Stopped)
            {
                return;
            }

            if (sender is IChecksumCalculator)
            {
                _readBytes += message.Size;
                streamWriter.Write($"\rTotal processed {_readBytes}b");
                PrintPercentage();
            }
            else if (sender is HashStreamWriterVisitor)
            {
                streamWriter.WriteLine($"Processing {message.FileName} - with length {message.Size}b");
                if (message.AlreadyProcessed)
                {
                    _readBytes += message.Size;
                    PrintPercentage();
                }
            }
            else
            {
                throw new ArgumentException("Invalid sender type");
            }
        }

        private void PrintPercentage()
        {
            var percentage = _readBytes / (double)_expectedBytesToRead * 100;
            var remainingTime = _stopwatch.ElapsedMilliseconds / percentage * (100 - percentage);
            streamWriter.Write($" Total processed {percentage:F6}%, remaining time {remainingTime:F0}ms");
        }
    }
}
