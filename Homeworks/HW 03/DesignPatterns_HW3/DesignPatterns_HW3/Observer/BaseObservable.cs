namespace DesignPatterns_HW3.Observer
{
    public abstract class BaseObservable : IObservable
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public virtual void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public virtual void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public virtual void Notify(IObservable sender, FileMessage message)
        {
            _observers.ForEach(observer => observer.Update(sender, message));
        }
    }
}
