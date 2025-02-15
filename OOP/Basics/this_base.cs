using System;

namespace Basics;

public class Computer
{
    public string? Brand { get; set; }
    public int? price { get; set; }
    public Computer(string brand, int price)
    {
        Brand = brand;
        this.price = price; // this.price is used to differentiate between the class property and the constructor parameter
    }
    public void Start()
    {
        Console.WriteLine("Computer started.");
    }

    public void Stop()
    {
        Console.WriteLine("Computer stopped.");
    }
}
public class SmartWatch : Computer
{
    public string? Model { get; set; }
    public SmartWatch(string brand, int price, string model) : base(brand, price)
    {
        Model = model;
    }
    //By default refers to the class property so this can be omitted
    public void DisplayInfo()
    {
        Console.WriteLine($"Brand: {this.Brand}, Price: {price}, Model: {Model}");
    }
    //new keyword is used to hide the base class method
    //This means that if you call the method on an instance of the derived class, the derived class's version of the method will be executed, not the base class's version. 
    public new void Start()
    {
        base.Start(); // Calls the Start method from the base class
    }
}
/****
SmartWatch samsungGalaxy = new SmartWatch(brand: "Samsung", price: 200, model: "Galaxy Watch 4");
//Show the information of the smartwatch
samsungGalaxy.DisplayInfo();
//Call the Start method which in turn calls the base class method
samsungGalaxy.Start();
 ****/