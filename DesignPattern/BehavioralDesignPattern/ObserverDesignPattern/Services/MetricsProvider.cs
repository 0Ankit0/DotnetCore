using ObserverDesignPattern.Models;

namespace ObserverDesignPattern.Services
{
    public class MetricsProvider : IObservable<MetricsData>
    {
        private readonly List<IObserver<MetricsData>> _observers = new();
        private Timer _timer;

        public MetricsProvider()
        {
            // Start a timer to generate new metrics every second
            _timer = new Timer(GenerateMetrics, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
        }

        public IDisposable Subscribe(IObserver<MetricsData> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }

            // Return an IDisposable that removes the observer upon disposal
            return new Unsubscriber(_observers, observer);
        }

        private void GenerateMetrics(object? state)
        {
            // Simulated CPU usage (in real code, read from PerformanceCounter or other sources)
            double simulatedCpu = new Random().NextDouble() * 100.0;

            var data = new MetricsData
            {
                CpuUsagePercentage = Math.Round(simulatedCpu, 2),
                Timestamp = DateTime.Now
            };

            // Notify all observers
            foreach (var observer in _observers)
            {
                observer.OnNext(data);
            }
        }

        private class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<MetricsData>> _localObservers;
            private readonly IObserver<MetricsData> _localObserver;

            public Unsubscriber(List<IObserver<MetricsData>> observers, IObserver<MetricsData> observer)
            {
                _localObservers = observers;
                _localObserver = observer;
            }

            public void Dispose()
            {
                if (_localObserver != null && _localObservers.Contains(_localObserver))
                {
                    _localObservers.Remove(_localObserver);
                }
            }
        }
    }
}
