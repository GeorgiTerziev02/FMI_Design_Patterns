namespace DesignPatterns_HW3.Observer
{
    public class FileMessage
    {
        public FileMessage(string fileName, ulong size, bool alreadyProcessed = false)
        {
            FileName = fileName;
            Size = size;
            AlreadyProcessed = alreadyProcessed;
        }

        public string FileName { get; }
        
        public ulong Size { get; }

        public bool AlreadyProcessed { get; }
    }
}
