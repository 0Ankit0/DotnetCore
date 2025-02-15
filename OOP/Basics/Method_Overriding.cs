using System;

namespace Basics;

public class Institution
{
    public string? Name { get; set; }
    public string? Location { get; set; }
    public Institution(string name, string location)
    {
        Name = name;
        Location = location;
        Console.WriteLine("Institution Constructor Called");
    }
    // The virtual keyword allows the method to be overridden in a derived class
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Location: {Location}");
    }
    public virtual void EnrollStudent(string studentName)
    {
        Console.WriteLine($"{studentName} has been enrolled in {Name} Institution.");
    }
    public virtual void EnrollStudent(string studentName, string course)
    {
        Console.WriteLine($"{studentName} has been enrolled in {course} at {Name} Institution.");
    }
}
public class School : Institution
{
    public int? NumberOfStudents { get; set; }

    public School(string name, string location, int numberOfStudents) : base(name, location)
    {
        NumberOfStudents = numberOfStudents;
        Console.WriteLine("School Constructor Called");
    }
    // The override keyword is used to provide a new implementation of a method in a derived class
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Number of Students: {NumberOfStudents}");
    }
    // The sealed keyword prevents a method from being overridden in a derived class
    public sealed override void EnrollStudent(string studentName, string course)
    {
        Console.WriteLine($"{studentName} has been enrolled in {course} at {Name} School (sealed method).");
    }

    // The new keyword hides the base class method without overriding it
    public new void EnrollStudent(string studentName)
    {
        Console.WriteLine($"{studentName} has been enrolled in {Name} School (new method).");
    }
}

public class University : School
{
    public string UniversityType { get; set; }

    public University(string name, string location, int numberOfStudents, string universityType) : base(name, location, numberOfStudents)
    {
        UniversityType = universityType;
        Console.WriteLine("University Constructor Called");
    }

    // This will cause a compile-time error because EnrollStudent is sealed in School
    // public override void EnrollStudent(string studentName, string course)
    // {
    //     Console.WriteLine($"{studentName} has been enrolled in {course} at {Name} (attempted override).");
    // }
}

/****
Console.WriteLine("\n==============Institution======================\n");
// Creating an instance of the Institution class
Institution institution = new Institution(name: "Generic", location: "City Center");
institution.DisplayInfo();
institution.EnrollStudent("Alice");
institution.EnrollStudent("Lewis", "Mathematics");


Console.WriteLine("\n==============School======================\n");
// Creating an instance of the School class
School school = new School(name: "Greenwood High", location: "Suburb", numberOfStudents: 500);
school.DisplayInfo();
school.EnrollStudent("Charlie");
school.EnrollStudent("Dave", "Science");

Console.WriteLine("\n==============Access hidden method======================\n");
// Accessing the hidden method from the base class
Institution institution2 = new School(name: "Western Middle", location: "City", numberOfStudents: 654);
institution2.EnrollStudent("Eve");

Console.WriteLine("\n==============University======================\n");
// Creating an instance of the University class
University university = new University(name: "Tech University", location: "Downtown", numberOfStudents: 2000, universityType: "Public");
university.DisplayInfo();
university.EnrollStudent("Eve");
university.EnrollStudent("Frank", "Engineering");
 ****/