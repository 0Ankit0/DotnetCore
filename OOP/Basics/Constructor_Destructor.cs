using System;

namespace Basics;

public class Laptop : IDisposable
{
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }
    private bool disposed = false; // Tracks whether Dispose has been called

    public Laptop(string brand, string type, string name)
    {
        Brand = brand;
        Type = type;
        Name = name;
    }

    // Implementing IDisposable interface
    public void Dispose()
    {
        Dispose(true);
        //The SuppressFinalize method prevents the destructor from being called.
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Console.WriteLine("Dispose Called");
                // Free any other managed objects here.
                // If you have any managed resources, dispose of them here.
            }

            Console.WriteLine("Disposing Unmanaged Resources");
            // Free any unmanaged resources here.
            disposed = true; // Mark as disposed
        }
    }

    // Destructor
    ~Laptop()
    {
        Dispose(false);
        Console.WriteLine("Destructor Called");
    }
}

/****
// Creating an instance of the Laptop class
// IDisposable is preferred over destructors because it provides a deterministic way to release resources.
// The Dispose method can be called explicitly to free resources, whereas destructors are called by the garbage collector non-deterministically.
Laptop myLaptop = new Laptop("Dell", "Gaming", "Alienware");
Console.WriteLine($"Brand: {myLaptop.Brand}, Type: {myLaptop.Type}, Name: {myLaptop.Name}");

// Explicitly calling Dispose method to release resources
myLaptop.Dispose();

// The Dispose method will be called automatically when myLaptop goes out of scope if used within a using statement
// using (Laptop myLaptop = new Laptop("Dell", "Gaming", "Alienware"))
// {
//     Console.WriteLine($"Brand: {myLaptop.Brand}, Type: {myLaptop.Type}, Name: {myLaptop.Name}");
// }
 ****/