namespace DesignPatterns_HW3.Common
{
    public abstract class BaseStreamWriter : IDisposable
    {
        protected readonly Stream stream;
        protected readonly StreamWriter streamWriter;

        public BaseStreamWriter(Stream outputStream)
        {
            stream = outputStream;
            streamWriter = new StreamWriter(stream)
            {
                AutoFlush = true
            };
        }

        public void Dispose()
        {
            streamWriter.Dispose();
            stream.Dispose();
            GC.SuppressFinalize(this);
        }

        ~BaseStreamWriter()
        {
            Dispose();
        }
    }
}
