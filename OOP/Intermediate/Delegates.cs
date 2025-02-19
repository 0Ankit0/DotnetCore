using System;

namespace Intermediate;

public class Delegates
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public int Add(int a, int b)
    {
        return a + b;
    }

    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }

}
/****
Delegates delegateEx = new Delegates();
//Action<T> – A Delegate That Returns void
//Here T is the type of the parameter passed to the delegate
Action<string> action = delegateEx.ShowMessage;
action("Hello World!");

//Func<T, TResult> – A Delegate That Returns a Value
//The last type parameter is always the return type no matter how many parameters are passed
Func<int, int, int> Add = delegateEx.Add;
Console.WriteLine(Add(10, 20));

//Predicate<T> – A Delegate That Returns a Boolean
//Here T is the type of the parameter passed to the delegate
Predicate<int> predicate = delegateEx.IsEven;
Console.WriteLine(predicate(1));
 ****/