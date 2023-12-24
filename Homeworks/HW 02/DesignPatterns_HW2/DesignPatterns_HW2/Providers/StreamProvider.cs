namespace DesignPatterns_HW2.Providers
{
    public interface IStreamProvider
    {
        Stream GetStdIn();
    }

    public class StreamProvider : IStreamProvider
    {
        public Stream GetStdIn()
        {
            return Console.OpenStandardInput();
        }
    }
}
