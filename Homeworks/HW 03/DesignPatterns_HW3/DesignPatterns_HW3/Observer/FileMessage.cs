namespace DesignPatterns_HW3.Observer
{
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
