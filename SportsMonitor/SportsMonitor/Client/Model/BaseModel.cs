using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SportsMonitor.Client.Model;

public abstract class BaseModel<T>: INotifyPropertyChanged, IObservable<T>
{
    private List<IObserver<T>> _observers = new ();

    public Guid Id { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public IDisposable Subscribe(IObserver<T> observer)
    {
        if (observer == null)
        {
            throw new ArgumentNullException("Observer cannot be null.");
        }

        _observers.Add(observer);
        return new Unsubscriber(this, observer);
    }

    public abstract T GetRecord();

    protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        foreach (var observer in _observers)
        {
            observer.OnNext(GetRecord());
        }
    }

    private class Unsubscriber : IDisposable
    {
        private readonly BaseModel<T> _baseModel;
        private IObserver<T> _observer;

        public Unsubscriber(BaseModel<T> baseModel, IObserver<T> observer)
        {
            _baseModel = baseModel;
            _observer = observer;
        }

        public void Dispose()
        {
            _baseModel._observers.Remove(_observer);
        }
    }
}
