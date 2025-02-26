using System;

namespace Intermediate;

public class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Deconstruct method to enable deconstruction
    // The method should have the Deconstruct name and return void
    // The method should have out parameters for each property to deconstruct
    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    public override string ToString() => $"Point({X}, {Y})";
}

/****
// Create an instance of the Point class
var point = new Point(3, 4);

// Deconstruct the point object into two variables
//It is same as writing int x = point.X; int y = point.Y;
var (x, y) = point;
Console.WriteLine($"x: {x}, y: {y}");

//You can also use the Deconstruct method directly
point.Deconstruct(out int x1, out int y1);
Console.WriteLine($"x1: {x1}, y1: {y1}");
 ****/