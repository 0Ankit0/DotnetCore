using Microsoft.AspNetCore.SignalR;
using ObserverDesignPattern.Models;
using ObserverDesignPattern.Services.Hubs;

namespace ObserverDesignPattern.Services
{
    public class MetricsHubObserver : IObserver<MetricsData>
    {
        private readonly IHubContext<MetricsHub> _hubContext;

        public MetricsHubObserver(IHubContext<MetricsHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void OnNext(MetricsData value)
        {
            // Broadcast to all clients in real-time
            // "ReceiveMetrics" is a method the client-side will implement
            _hubContext.Clients.All.SendAsync("ReceiveMetrics", value);
        }

        public void OnError(Exception error)
        {
            // Handle errors if needed
            Console.WriteLine($"Error in MetricsHubObserver: {error.Message}");
        }

        public void OnCompleted()
        {
            // We can notify clients that metrics are done,
            // but typically metrics might run indefinitely.
            Console.WriteLine("Metrics stream completed.");
        }
    }
}
