using System;

namespace Intermediate;

//Operator overloading is a feature that allows us to define how operators should work with our custom types.
//We can overload most of the operators in C#.
public class Operator_Overloading
{
    public float X { get; set; }
    public float Y { get; set; }

    public Operator_Overloading(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static Operator_Overloading operator +(Operator_Overloading a, Operator_Overloading b)
    {
        return new Operator_Overloading(a.X + b.X, a.Y + b.Y);
    }

    public static Operator_Overloading operator -(Operator_Overloading a, Operator_Overloading b)
    {
        return new Operator_Overloading(a.X - b.X, a.Y - b.Y);
    }

    public static Operator_Overloading operator *(Operator_Overloading a, Operator_Overloading b)
    {
        return new Operator_Overloading(a.X * b.X, a.Y * b.Y);
    }

    public static Operator_Overloading operator /(Operator_Overloading a, Operator_Overloading b)
    {
        return new Operator_Overloading(a.X / b.X, a.Y / b.Y);
    }

    public static bool operator ==(Operator_Overloading a, Operator_Overloading b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Operator_Overloading a, Operator_Overloading b)
    {
        return a.X != b.X || a.Y != b.Y;
    }

    public override string ToString()
    {
        return $"X: {X}, Y: {Y}";
    }
    public override bool Equals(object? obj)
    {
        //If the object is an instance of the same class, then assign it to variable other and compare the values of the two objects.
        if (obj is Operator_Overloading other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

}

/****
Operator_Overloading a = new Operator_Overloading(10, 20);
Operator_Overloading b = new Operator_Overloading(30, 40);

Operator_Overloading c = a + b;
Operator_Overloading d = a - b;
Operator_Overloading e = a * b;
Operator_Overloading f = a / b;
bool eq = a.Equals(b);
int hash = a.GetHashCode();

Console.WriteLine($"The sum of ( {a} ) + ( {b} ) is {c}");
Console.WriteLine($"The difference of ( {a} ) - ( {b} ) is {d}");
Console.WriteLine($"The product of ( {a} ) * ( {b} ) is {e}");
Console.WriteLine($"The division of ( {a} ) / ( {b} ) is {f}");
Console.WriteLine($"Are ( {a} ) and ( {b} ) equal? {eq}");
Console.WriteLine($"The hash code of ( {a} ) is {hash}");
Console.WriteLine($"The string representation of ( {a} ) is {a.ToString()}");

 ****/