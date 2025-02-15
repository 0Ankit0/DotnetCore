using System;

namespace Basics;

public class Shape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a shape");
    }

    // Method overloading: Different parameters but same method name
    public void Area(int side)
    {
        Console.WriteLine($"Area of square: {side * side}");
    }

    public void Area(int length, int breadth)
    {
        Console.WriteLine($"Area of rectangle: {length * breadth}");
    }

    public void Area(double radius)
    {
        Console.WriteLine($"Area of circle: {Math.PI * radius * radius}");
    }
}

/****
Shape shape = new Shape();
shape.Draw();
shape.Area(5);
shape.Area(5, 10);
shape.Area(5.5);
 ****/