using System;

namespace Advanced;

public class MyResource : IDisposable
{
    // Flag to indicate whether the resource has been disposed
    private bool disposed = false;

    public void DoWork()
    {
        if (disposed)
            throw new ObjectDisposedException("MyResource");

        Console.WriteLine("Working with the resource...");
    }

    // Implement the Dispose method
    public void Dispose()
    {
        Dispose(true);
        //The SuppressFinalize method is called to prevent the finalizer/Destructor from running.
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern
    //The disposing parameter is used to determine whether the method is called by the Dispose method or the finalizer.
    //If disposing is true, the method is called by the Dispose method and we can free both managed and unmanaged resources.
    //If disposing is false, the method is called by the finalizer and we can only free unmanaged resources.
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Free any other managed objects here.
                // If you have any managed resources, dispose of them here.
            }

            // Free any unmanaged resources here.
            // If you have any unmanaged resources, release them here.

            disposed = true;
        }
    }

    // Finalizer/Destructor
    //Here, we release the unmanaged resources like file handles, network connections, etc. which are not managed by the garbage collector.
    //The finalizer is called by the garbage collector and it is used to clean up unmanaged resources before the object is destroyed if the Dispose method is not called.
    ~MyResource()
    {
        Dispose(false);
    }
}
/****
using (var resource = new MyResource())
{
    resource.DoWork();
}//The Dispose method is called automatically when the using block is exited.
 ****/