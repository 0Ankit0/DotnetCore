using System;

namespace Basics;
public class Person
{
    public string Name;
    public int Age;
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class Animal
{
    //The required keyword is used to make the property mandatory.
    public required string Type;
    public string? Color;
}


/****
 //This is the first method to create an object. It basically calls the constructor of the class.
Person person = new Person("John", 30);

//The second method is to use Object Initializer. It is a shorthand way to create an object and set its properties.
Animal dog = new Animal
{
    Type = "Dog",
    Color = "Black"
};

//if we directly print the object, it will print the namespace and class name as it stores the reference and not the value.
Console.WriteLine($"The type of person is {person}");
Console.WriteLine($"The type of dog is {dog}");
 ****/