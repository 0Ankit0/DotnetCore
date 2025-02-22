using System;

namespace Intermediate;

public interface IMovable
{
    void Move();
}
public interface IFlyable
{
    void Fly();
}
//We can implement multiple interfaces in a class.
public class SuperVehicle : IMovable, IFlyable
{
    public void Move()
    {
        Console.WriteLine("The vehicle is moving.");
    }

    public virtual void Fly()
    {
        Console.WriteLine("The vehicle is flying.");
    }
}
//We can also inherit from a class and implement multiple interfaces.
//But we can't inherit from multiple classes.
public class SuperCar : SuperVehicle, IMovable, IFlyable
{
    public new void Move()
    {
        Console.WriteLine("The car is moving.");
    }
    public override void Fly()
    {
        Console.WriteLine("The car is flying.");
    }
}

/****
SuperVehicle superVehicle = new SuperVehicle();
superVehicle.Move();
superVehicle.Fly();

SuperCar superCar = new SuperCar();
superCar.Move();
superCar.Fly();
 ****/