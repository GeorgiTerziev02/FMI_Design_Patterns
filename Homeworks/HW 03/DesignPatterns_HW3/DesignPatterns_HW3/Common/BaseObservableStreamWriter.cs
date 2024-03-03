using DesignPatterns_HW3.Observer;

namespace DesignPatterns_HW3.Common
{
    // No multiple inheritance in C#...
    public class BaseObservableStreamWriter : BaseObservable, IDisposable
    {
        protected readonly Stream stream;
        protected readonly StreamWriter streamWriter;

        public BaseObservableStreamWriter(Stream outputStream)
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

        ~BaseObservableStreamWriter()
        {
            Dispose();
        }
    }
}
