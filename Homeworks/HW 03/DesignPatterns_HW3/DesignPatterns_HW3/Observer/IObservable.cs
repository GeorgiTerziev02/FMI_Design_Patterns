namespace DesignPatterns_HW3.Observer
{
    public interface IObservable
    {
        void Attach(IObserver observer);
        
        void Detach(IObserver observer);
        
        void Notify(IObservable sender, FileMessage message);
    }
}
