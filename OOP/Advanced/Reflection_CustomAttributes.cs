using System;

namespace Advanced;

//a basic class without any custom attributes
public class Vehicle
{
    public string? Name { get; set; }
    public string? Model { get; set; }
    public void Drive()
    {
        Console.WriteLine("Driving");
    }
    public void Stop()
    {
        Console.WriteLine("Stopping");
    }
}

//First we define a custom attribute class that inherits from the Attribute class
//The attribute class can be used to define custom attributes that can be applied to classes, methods, properties, etc.
//We are only allowing the custom attribute to be applied to classes and methods using the AttributeUsage attribute
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAttribute : Attribute
{
    public string? Description { get; set; }
    public CustomAttribute(string description)
    {
        Description = description;
    }
}

//Applying the custom attribute to the Animal class
[CustomAttribute("This is a custom attribute applied to the Animal class")]
public class Animal
{
    public string? Name { get; set; }
    public string? Type
    {
        [CustomAttribute("This is a custom attribute applied to the get method Type property")]
        get;
        [CustomAttribute("This is a custom attribute applied to the set method Type property")]
        set;
    }
    [CustomAttribute("This is a custom attribute applied to the Eat method")]
    public void Eat()
    {
        Console.WriteLine("Eating");
    }
    [CustomAttribute("This is a custom attribute applied to the Sleep method")]
    public void Sleep()
    {
        Console.WriteLine("Sleeping");
    }
}

/**** 
using System.Reflection;

//Without using the CustomAttribute class, we can still use reflection to get information about the Vehicle class
//We can get the properties and methods of the class using reflection
Type type = typeof(Vehicle);

// Get the properties of the class
PropertyInfo[] properties = type.GetProperties();
foreach (var property in properties)
{
    Console.WriteLine("Property: " + property.Name);
}

// Get the methods of the class, excluding inherited methods from Object
MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
foreach (var methodData in methods)
{
    Console.WriteLine("Method: " + methodData.Name);
}


//We can get the custom attributes applied to the class and its methods using reflection
//Custom attribute helps to add metadata to classes, methods, properties, etc. that can be used for various purposes like validation, documentation, etc.
Type cusAttrType = typeof(Animal);

// Get the custom attributes of the class
//The false parameter indicates that we are not looking for inherited custom attributes
object[] classAttributes = cusAttrType.GetCustomAttributes(typeof(CustomAttribute), false);
foreach (CustomAttribute attr in classAttributes)
{
    Console.WriteLine("Class Attribute: " + attr.Description);
}

// Get the custom attributes of the methods
MethodInfo[] animalMethods = cusAttrType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
foreach (MethodInfo method in animalMethods)
{
    //We obtain all the custom attributes applied to the method then iterate through them
    object[] methodAttributes = method.GetCustomAttributes(typeof(CustomAttribute), false);
    foreach (CustomAttribute attr in methodAttributes)
    {
        Console.WriteLine("Method Attribute: " + attr.Description + " for method: " + method.Name);
    }
}
 ****/