using System;

namespace Intermediate;

public class Lambda_Linq
{
    public void PrintEvenNumbers(List<int> numbers)
    {
        //Here the Where method is an extension method that takes a lambda expression as a parameter.
        //The lambda expression is n => n % 2 == 0. This lambda expression is a predicate that takes an integer n as a parameter and returns a boolean value.
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number);
        }
    }


    public void ExampleSelectMany()
    {
        var listOfLists = new List<Person>
            {
                new Person { Name = "John", PhoneNumbers = new List<string> { "123", "456", "789" } },
                new Person { Name = "Jane", PhoneNumbers = new List<string> { "987", "654", "321" } }
            };

        // Using SelectMany to flatten the list of phone numbers into a single list of anonymous objects containing Name and PhoneNumber
        var flattenedList = listOfLists.SelectMany(
            person => person.PhoneNumbers!,
            (person, phoneNumber) => new { person.Name, PhoneNumber = phoneNumber }
        );

        Console.WriteLine("Flattened list:");
        foreach (var item in flattenedList)
        {
            Console.WriteLine($"Name: {item.Name}, PhoneNumber: {item.PhoneNumber}");
        }
    }
}
public class Person
{
    public string? Name { get; set; }
    public List<string>? PhoneNumbers { get; set; }
}

/****
Lambda_Linq lambdaLinq = new Lambda_Linq();
lambdaLinq.PrintEvenNumbers(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
lambdaLinq.ExampleSelectMany();
 ****/