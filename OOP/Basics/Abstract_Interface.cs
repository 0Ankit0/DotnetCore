using System;

namespace Basics;
public interface IWearable
{
    void PutOn();
    void TakeOff();
}
public abstract class Accessory : IWearable
{
    public string? Brand { get; set; }
    public string? Color { get; set; }

    public Accessory(string brand, string color)
    {
        Brand = brand;
        Color = color;
        Console.WriteLine("Accessory Constructor Called");
    }

    // The abstract keyword requires derived classes to implement this method
    public abstract void DisplayInfo();

    // A regular method that can be used by derived classes
    public void Wear()
    {
        Console.WriteLine($"Wearing {Brand} {Color} accessory.");
    }

    // Implementing the methods from IWearable
    public virtual void PutOn()
    {
        Console.WriteLine($"Putting on the {Brand} {Color} accessory.");
    }

    public virtual void TakeOff()
    {
        Console.WriteLine($"Taking off the {Brand} {Color} accessory.");
    }
}

public class Watch : Accessory
{
    public string Type { get; set; }

    public Watch(string brand, string color, string type) : base(brand, color)
    {
        Type = type;
        Console.WriteLine("Watch Constructor Called");
    }

    // Implementing the abstract method from Accessory
    public override void DisplayInfo()
    {
        Console.WriteLine($"Watch: {Brand} {Color}, Type: {Type}");
    }
}
public class Hat : Accessory
{
    public string Size { get; set; }

    public Hat(string brand, string color, string size) : base(brand, color)
    {
        Size = size;
        Console.WriteLine("Hat Constructor Called");
    }

    // Implementing the abstract method from Accessory
    public override void DisplayInfo()
    {
        Console.WriteLine($"Hat: {Brand} {Color}, Size: {Size}");
    }
}

/****
//Only one abstract class can be inherited  but multiple interfaces can be inherited in derived class
//Interface only contains method signature and no implementation while abstract class can contain method implementation
Console.WriteLine("\n==============Watch======================\n");
// Creating an instance of the Watch class using the parameterized constructor
Watch watch = new Watch(brand: "Rolex", color: "Gold", type: "Analog");
watch.DisplayInfo();
watch.Wear();
watch.PutOn();
watch.TakeOff();

Console.WriteLine("\n==============Hat======================\n");
// Creating an instance of the Hat class using the parameterized constructor
Hat hat = new Hat(brand: "Nike", color: "Black", size: "Medium");
hat.DisplayInfo();
hat.Wear();
hat.PutOn();
hat.TakeOff();

Console.WriteLine("\n==============Polymorphism with Collection======================\n");
// Using polymorphism with a collection of IWearable objects
List<IWearable> wearables = new List<IWearable>
        {
            new Watch(brand: "Casio", color: "Silver", type: "Digital"),
            new Hat(brand: "Adidas", color: "White", size: "Large")
        };

foreach (var wearable in wearables)
{
    wearable.PutOn();
    wearable.TakeOff();
}
 ****/