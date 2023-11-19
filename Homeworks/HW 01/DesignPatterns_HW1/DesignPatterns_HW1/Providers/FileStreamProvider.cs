namespace DesignPatterns_HW1.Providers
{
    public interface IStreamProvider
    {
        Stream OpenFileForRead(string fileName);

        Stream GetStdIn();
    }

    public class StreamProvider : IStreamProvider
    {
        public Stream GetStdIn()
        {
            return Console.OpenStandardInput();
        }

        public Stream OpenFileForRead(string fileName)
        {
            return new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
        }
    }
}
