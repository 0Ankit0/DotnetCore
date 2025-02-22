using System;

namespace Intermediate;

public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea() => Math.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea() => Width * Height;
}

public class Triangle : Shape
{
    public double Base { get; }
    public double Height { get; }

    //Here we are using the @ symbol to escape the reserved keyword base.
    public Triangle(double @base, double height)
    {
        Base = @base;
        Height = height;
    }

    public override double CalculateArea() => 0.5 * Base * Height;
}

//In this class we have a static method CalculateArea that takes a Shape object and returns a tuple with the shape type and the area of the shape.
//Tuple is a new feature in C# 7.0 that allows you to return multiple values from a method.
//The CalculateArea method uses pattern matching to determine the type of the shape and calculate the area.
//The switch statement is used to match the shape type and call the CalculateArea method of the corresponding shape class.
public static class ShapeCalculator
{
    public static (string ShapeType, double Area) CalculateArea(Shape shape)
    {
        return shape switch
        {
            Circle c => ("Circle", c.CalculateArea()),
            Rectangle r => ("Rectangle", r.CalculateArea()),
            Triangle t => ("Triangle", t.CalculateArea()),
            _ => throw new ArgumentException("Unknown shape", nameof(shape))
        };
    }
}
/****
Shape[] shapes = new Shape[]
            {
                new Circle(5),
                new Rectangle(4, 6),
                new Triangle(3, 4)
            };

foreach (var shape in shapes)
{
    var (shapeType, area) = ShapeCalculator.CalculateArea(shape);
    Console.WriteLine($"The area of the {shapeType} is {area}");
}
 ****/