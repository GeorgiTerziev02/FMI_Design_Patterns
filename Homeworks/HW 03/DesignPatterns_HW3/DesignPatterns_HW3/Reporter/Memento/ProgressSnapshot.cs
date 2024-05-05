namespace DesignPatterns_HW3.Reporter.Memento
{
    public class ProgressSnapshot
    {
        public ProgressSnapshot(ulong readBytes, ulong expectedBytesToRead, long elapsedMilliseconds)
        {
            ReadBytes = readBytes;
            ExpectedBytesToRead = expectedBytesToRead;
            ElapsedMilliseconds = elapsedMilliseconds;
        }

        public ulong ReadBytes { get; }
        public ulong ExpectedBytesToRead { get; }
        public long ElapsedMilliseconds { get; }
    }
}
