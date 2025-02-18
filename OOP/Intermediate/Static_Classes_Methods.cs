using System;

namespace Intermediate;

//Static classes are those classes that cannot be instantiated. They are sealed classes with static members.
//Static classes are used to create data and functions that are not tied to a particular object.
//you can access the members of a static class by using the class name itself.
public static class Static_Classes_Methods
{
    public static string Name = "Static_Classes_Properties";
    public static void Run()
    {
        Console.WriteLine("Static_Classes_Methods");
    }

}
/****
Static_Classes_Methods.Run();
Console.WriteLine(Static_Classes_Methods.Name);
//If you try to create an instance of a static class, you will get a compile-time error.
Static_Classes_Methods obj = new Static_Classes_Methods(); //Error: 'Static_Classes_Methods': static classes cannot be instantiated

 ****/
