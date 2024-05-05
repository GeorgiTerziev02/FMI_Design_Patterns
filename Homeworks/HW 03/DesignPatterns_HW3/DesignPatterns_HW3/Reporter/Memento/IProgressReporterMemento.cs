namespace DesignPatterns_HW3.Reporter.Memento
{
    public interface IProgressReporterMemento : IProgressReporter
    {
        bool Stopped { get; }

        void Pause();

        ProgressSnapshot GetSnapshot();

        void Restore(ProgressSnapshot snapshot);
    }
}
