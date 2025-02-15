using System;

namespace Basics;

public class Utensils
{
    private string? _type;
    private string? _material;
    private string? _color;

    //if the setter is not specified we can't set the value from outside the class
    public string Type
    {
        get
        {
            return _type ?? "No Type Specified";
        }
    }

    //if the getter is not specified we can't get the value from outside the class
    public string Material
    {
        set
        {
            _material = value;
        }
    }

    public string Color
    {
        get
        {
            return _color ?? "No Color Specified";
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Color can't be null or empty");
            }
            _color = value;
        }
    }


}

/****
 Utensils pan = new Utensils();
pan.Material = "Iron";
pan.Color = ""; //This will give an error because of the setter condition
pan.Color = "Black";
pan.Type = "Cooking Pan"; //this will give an error because the setter is not specified

Console.WriteLine($"Material: {pan.Material}"); //This will give an error because the getter is not specified
Console.WriteLine($"Type: {pan.Type}"); //Output: Type: No Type Specified
Console.WriteLine($"Color: {pan.Color}"); //Output: Color: Black
 ****/
