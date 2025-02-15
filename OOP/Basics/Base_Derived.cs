using System;

namespace Basics;

public class Vehicle
{
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }

    public Vehicle(string brand, string type, string name)
    {
        Brand = brand;
        Type = type;
        Name = name;
    }
    public void Start()
    {
        Console.WriteLine("Vehicle started");
    }
    public void Stop()
    {
        Console.WriteLine("Vehicle stopped");
    }

}
public class Car : Vehicle
{
    public string? Model { get; set; }
    public Car(string brand, string type, string name, string model) : base(brand, type, name)
    {
        Model = model;
    }
    public void Honk()
    {
        Console.WriteLine("Car honked");
    }
}

/****
// Creating an instance of the Car class
Car myCar = new Car(brand: "Toyota", type: "Sedan", name: "Corolla", model: "2021");
Console.WriteLine($"Brand: {myCar.Brand}, Type: {myCar.Type}, Model: {myCar.Model}");

// Calling methods from the base class
myCar.Start();
myCar.Stop();

// Calling method from the derived class
myCar.Honk();
 ****/