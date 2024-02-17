namespace DesignPatterns_HW3.Observer
{
    public abstract class Observable : IObservable
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(IObservable sender, FileMessage message)
        {
            _observers.ForEach(observer => observer.Update(sender, message));
        }
    }
}
