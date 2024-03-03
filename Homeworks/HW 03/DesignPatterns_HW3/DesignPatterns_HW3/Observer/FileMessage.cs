namespace DesignPatterns_HW3.Observer
{
    // TODO: refactor
    public class FileMessage
    {
        public FileMessage(string fileName, ulong size)
        {
            FileName = fileName;
            Size = size;
        }

        public string FileName { get; }
        
        public ulong Size { get; }
    }
}
