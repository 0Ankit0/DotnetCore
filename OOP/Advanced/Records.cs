using System;

namespace Advanced;
/****
 Records are immutable by default, which means that the data they contain cannot be modified after the record is created.
Records are reference types, but they provide value-based equality.
Records are defined using the record keyword.
Records can be used to create immutable objects that are used to store data.
They are useful for creating data transfer objects (DTOs) and for representing data in a way that is easy to work with.
Records are similar to classes, but they are more lightweight and provide built-in functionality for equality, immutability, and value-based semantics.
 ****/
//
public record Person(string FirstName, string LastName, int Age);

/****
// Create an instance of the Person record
var person1 = new Person("John", "Doe", 30);
var person2 = new Person("Jane", "Doe", 25);

// Display the person details
Console.WriteLine(person1);
Console.WriteLine(person2);

// Records provide value-based equality
var person3 = new Person("John", "Doe", 35);
Console.WriteLine($"person1 equals person3: {person1 == person3}");

// Records are immutable by default
// To create a modified copy, use the with expression
var person4 = person1 with { Age = 31 };
Console.WriteLine(person4);
 ****/