using DesignPatterns_HW3.Observer;

namespace DesignPatterns_HW3.Reporter
{
    public interface IProgressReporter : IObserver
    {
        void StartTimer(ulong expectedTotalBytes);

        long EndTimer();
    }
}
