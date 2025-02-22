using System;

namespace Intermediate;

//The interface segregation principle (ISP) states that a class should not be forced to implement an interface that it does not use.
//It means that we should create a separate interface for each functionality, instead of creating a single interface with multiple functionalities.
public interface IOrderService
{
    void ProcessOrder(string order);
}
public interface ILogger
{
    void Log(string message);
}
//Each class should have a single responsibility. The OrderService class processes orders, and the ConsoleLogger class logs messages.
//The OrderService class depends on the ILogger interface, which can be substituted with any implementation of ILogger.
//The ConsoleLogger class implements the ILogger interface and logs messages to the console.
public class OrderService : IOrderService
{
    private readonly ILogger _logger;

    public OrderService(ILogger logger)
    {
        _logger = logger;
    }

    public void ProcessOrder(string order)
    {
        // Process the order
        _logger.Log($"Order {order} processed.");
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

/****
We need to add the dependency injection container to the Program.cs file.
// Setup Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILogger, ConsoleLogger>()
                .AddSingleton<IOrderService, OrderService>()
                .BuildServiceProvider();
Then we can use the dependency injection container to resolve the dependencies and use them in the application.
            var orderService = serviceProvider.GetService<IOrderService>();
            orderService.ProcessOrder("12345");

Solid principles:
-Single Responsibility Principle (SRP):
    Each class has a single responsibility. OrderService processes orders, and ConsoleLogger logs messages.
-Open/Closed Principle (OCP):
    The system is open for extension but closed for modification. We can add new types of loggers without modifying existing code.
-Liskov Substitution Principle (LSP):
    OrderService depends on the ILogger interface, which can be substituted with any implementation of ILogger.
-Interface Segregation Principle (ISP):
    Interfaces are small and specific to their purpose.
-Dependency Inversion Principle (DIP):
    High-level modules (OrderService) depend on abstractions (ILogger), not on concrete implementations.
 ****/