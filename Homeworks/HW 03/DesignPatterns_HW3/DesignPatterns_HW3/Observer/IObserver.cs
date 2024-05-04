namespace DesignPatterns_HW3.Observer
{
    public interface IObserver
    {
        void Update(IObservable sender, FileMessage message);
    }
}
