using Microsoft.AspNetCore.SignalR;

namespace ObserverDesignPattern.Services.Hubs
{ 
    public class MetricsHub : Hub
    {
        // The client will call methods on the hub if needed,
        // but for now, we just broadcast server -> client updates.
    }
}
