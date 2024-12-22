namespace ObserverDesignPattern.Services
{
    public class MetricsSubscriptionService : IHostedService
    {
        private readonly MetricsProvider _metricsProvider;
        private readonly MetricsHubObserver _metricsObserver;
        private IDisposable? _subscription;

        public MetricsSubscriptionService( MetricsProvider provider, MetricsHubObserver observer)
        {
            _metricsProvider = provider;
            _metricsObserver = observer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Subscribe the observer to the provider
            _subscription = _metricsProvider.Subscribe(_metricsObserver);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Unsubscribe on shutdown
            _subscription?.Dispose();
            return Task.CompletedTask;
        }
    }
}
