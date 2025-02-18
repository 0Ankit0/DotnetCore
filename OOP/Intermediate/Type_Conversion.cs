using System;

namespace Intermediate;

//Type conversion is the process of converting one type of data to another type.
//There are two types of type conversion: implicit and explicit.
public class Type_Conversion
{
    public float X { get; set; }
    public float Y { get; set; }

    public Type_Conversion(float x, float y)
    {
        X = x;
        Y = y;
    }

    //Implicit conversion is done automatically by the compiler.
    //This is converting Type_Conversion to Operator_Overloading.
    public static implicit operator Type_Conversion(Operator_Overloading a)
    {
        return new Type_Conversion(a.X, a.Y);
    }

    //Explicit conversion is done by the user.
    //This is converting Operator_Overloading to Type_Conversion.
    public static explicit operator Operator_Overloading(Type_Conversion a)
    {
        return new Operator_Overloading(a.X, a.Y);
    }

    public override string ToString()
    {
        return $"X: {X}, Y: {Y}";
    }
}

/****
 //Implicit conversion is done automatically by the compiler.
Type_Conversion b = new Operator_Overloading(1, 2);

//Explicit conversion is done by the user.
Type_Conversion c = new Type_Conversion(3, 4);
Operator_Overloading d = (Operator_Overloading)c;

Console.WriteLine($"Implicit conversion: {b}");
Console.WriteLine($"Explicit conversion: {d}");

 ****/