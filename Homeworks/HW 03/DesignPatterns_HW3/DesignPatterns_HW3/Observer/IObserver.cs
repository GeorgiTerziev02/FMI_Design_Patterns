namespace DesignPatterns_HW3.Observer
{
    public interface IObserver
    {
        // TODO: probably have base message class and use it here
        // and later have inheritance for observer classes
        void Update(IObservable sender, FileMessage message);
    }
}
