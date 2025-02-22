using System;
using System.Threading;

namespace Intermediate;
public class Counter
{
    // The lock keyword marks a statement block as a critical section by obtaining the mutual-exclusion lock for a given object, executing a statement, and then releasing the lock.
    // The lock keyword ensures that one thread does not enter a critical section of code while another thread is in the critical section. If another thread tries to enter a locked code, it will wait, block, until the object is released.
    private readonly object _lock = new object();
    // The volatile keyword indicates that a field might be modified by multiple threads that are executing at the same time. Fields that are declared volatile are not subject to compiler optimizations that assume access by a single thread. This ensures that the most up-to-date value is present in the field at all times.
    private volatile int _count;

    public Counter(int initialCount)
    {
        _count = initialCount;
    }

    public void Increment()
    {
        lock (_lock)
        {
            _count++;
            Console.WriteLine($"Incremented, new count is {_count}");
        }
    }

    public void Decrement()
    {
        lock (_lock)
        {
            _count--;
            Console.WriteLine($"Decremented, new count is {_count}");
        }
    }

    public int GetCount()
    {
        bool lockTaken = false;
        try
        {
            // Monitor.Enter(_lock) is used to acquire the Monitor on the object passed as a parameter.
            // Monitor.Enter(_lock) is a blocking call, which means that if the Monitor is already acquired by another thread, the current thread will be blocked until the Monitor is released.
            Monitor.Enter(_lock, ref lockTaken);
            return _count;
        }
        finally
        {
            if (lockTaken)
            {
                Monitor.Exit(_lock);
            }
        }
    }
}

/****
var counter = new Counter(0);
// Create tasks to perform increments and decrements
var tasks = new Task[10];
for (int i = 0; i < 5; i++)
{
    //Here we are using Task.Run to run the Increment and Decrement methods in parallel
    tasks[i] = Task.Run(() => counter.Increment());
    tasks[i + 5] = Task.Run(() => counter.Decrement());
}

// Wait for all tasks to complete
Task.WaitAll(tasks);

Console.WriteLine($"Final count is {counter.GetCount()}");
 ****/