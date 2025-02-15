using System;

namespace Basics;

public class Laptop
{
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }

    public Laptop(string brand, string type, string name)
    {
        Brand = brand;
        Type = type;
        Name = name;
    }
    ~Laptop()
    {
        Console.WriteLine("Destructor Called");
    }

}
/****
// Creating an instance of the Laptop class
//Destructor is useful for cleaning up resources like closing a file, closing a connection, etc.
Laptop myLaptop = new Laptop("Dell", "Gaming", "Alienware");
Console.WriteLine($"Brand: {myLaptop.Brand}, Type: {myLaptop.Type}, Name: {myLaptop.Name}");

// The destructor will be called automatically when myLaptop goes out of scope
 ****/