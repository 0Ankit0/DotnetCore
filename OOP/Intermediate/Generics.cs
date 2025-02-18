using System;

namespace Intermediate;

public class Generics<T>
{
    private T? data;
    // public Generics(T value)
    // {
    //     data=value;
    // }
    public T GetValue()
    {
        return data;
    }
    public void SetValue(T value)
    {
        data = value;
    }
    public TL GetFirstElement<TL>(List<TL> items)
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("The collection is empty.");
        }
        //The exclamation mark (!) is used to tell the compiler that the value is not null.
        return items.FirstOrDefault()!;
    }

    //The type parameter TC is constrained to implement the IComparable<T> interface.
    //This means that the type argument for TC must be a type that can be compared to the type argument for T.
    //This ensures that the type of TC and T are compatible. 
    public T GenericMethodWithConstraints<TC>(T value) where TC : IComparable<T>
    {
        return value;
    }
}

/****
 Generics<int> generic = new Generics<int>();
generic.SetValue(100);
Console.WriteLine(generic.GetValue());

Console.WriteLine(generic.GetFirstElement(new List<int> { 1, 2, 3, 4, 5 }));
Console.WriteLine(generic.GenericMethodWithConstraints<int>(10));
 ****/