using System;

namespace Intermediate;

// Step 1: Define a custom EventArgs class
// This class will hold the data that will be passed to the event handler
public class SubscribeEventArgs : EventArgs
{
    public string Message { get; }

    public SubscribeEventArgs(string message)
    {
        Message = message;
    }
}

public class Publisher
{
    // Step 2: Use EventHandler<T> for the event
    public event EventHandler<SubscribeEventArgs>? SubscribeEventHander;

    public void OnSubscribe(string message)
    {
        // Step 3: Raise event with custom arguments
        //The Invoke method is used to trigger the event
        SubscribeEventHander?.Invoke(this, new SubscribeEventArgs(message));
    }
}

public class Subscriber
{
    //Here we subscribe to the event by adding an event handler
    public void Subscribe(Publisher events)
    {
        events.SubscribeEventHander += HandleEvent;
    }

    public void HandleEvent(object? sender, SubscribeEventArgs e)
    {
        // Step 4: Display received message
        Console.WriteLine($"Event triggered with message: {e.Message}");
    }
}


