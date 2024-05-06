namespace DesignPatterns_HW3.Visitor.Memento
{

    public interface IFileSystemEntityMementoVisitor : IFileSystemEntityVisitor
    {
        public bool Stopped { get; }

        void Pause();

        ProcessedFilesSnapshot GetSnapshot();

        void Restore(ProcessedFilesSnapshot snapshot);
    }
}
